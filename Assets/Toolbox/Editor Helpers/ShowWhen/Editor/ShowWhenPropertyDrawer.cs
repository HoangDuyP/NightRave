#if UNITY_EDITOR
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowWhenAttribute))]
public class HideWhenPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowWhenAttribute atb = (ShowWhenAttribute)attribute;
        bool enabled = Evaluate(atb, property);

        bool wasEnabled = GUI.enabled;
        GUI.enabled = enabled;
        if (!atb.HideInInspector || enabled) EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = wasEnabled;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ShowWhenAttribute atb = (ShowWhenAttribute)attribute;
        bool enabled = Evaluate(atb, property);

        if (!atb.HideInInspector || enabled) return EditorGUI.GetPropertyHeight(property, label);
        else return -EditorGUIUtility.standardVerticalSpacing;
    }

    private bool Evaluate(ShowWhenAttribute attribute, SerializedProperty property)
    {
        var conditionField = attribute.ConditionField.Replace(" ", "");
        return Evaluate(conditionField, property);
    }

    private bool Evaluate(string expression, SerializedProperty property)
    {
        if (expression.Contains("&&"))
        {
            var expressions = expression.Split("&&");
            return expressions.All(expression => Evaluate(expression, property));
        }
        else if (expression.Contains("||"))
        {
            var subExpressions = expression.Split("||");
            return subExpressions.Any(expression => Evaluate(expression, property));
        }

        var conditionFieldBuilder = new StringBuilder(expression);
        var propertyPath = property.propertyPath;

        var negation = false;
        if (conditionFieldBuilder[0] == '!')
        {
            negation = true;
            conditionFieldBuilder = conditionFieldBuilder.Remove(0, 1);
        }

        var conditionPath = propertyPath.Replace(property.name, conditionFieldBuilder.ToString());
        var conditionValue = property.serializedObject.FindProperty(conditionPath);

        if (conditionValue != null)
        {
            var evaluation = conditionValue.boolValue;
            if (negation) evaluation = !evaluation;
            return evaluation;
        }

        Debug.LogWarning("Attempting to use a HideWhenAttribute but no matching SourcePropertyValue found in object: " + expression);
        return true;
    }
}
#endif