using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class SerializeHelper
{
    public static object GetParent(this SerializedProperty prop) => GetObject(prop, -1);

    public static object GetObject(this SerializedProperty prop, int depthOffset = 0)
    {
        var path = prop.propertyPath.Replace(".Array.data[", "[");
        object obj = prop.serializedObject.targetObject;
        var elements = path.Split('.');
        foreach (var element in elements.Take(elements.Length + depthOffset))
        {
            if (element.Contains("["))
            {
                var elementName = element.Substring(0, element.IndexOf("["));
                var index = Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
                obj = GetValue(obj, elementName, index);
            }
            else obj = GetValue(obj, element);
        }
        return obj;
    }

    public static object GetValue(object source, string name)
    {
        if (source == null)
            return null;
        var type = source.GetType();
        var f = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        if (f == null)
        {
            var p = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p == null)
                return null;
            return p.GetValue(source, null);
        }
        return f.GetValue(source);
    }

    public static object GetValue(object source, string name, int index)
    {
        var enumerable = GetValue(source, name) as IEnumerable;
        var enm = enumerable.GetEnumerator();
        while (index-- >= 0)
            enm.MoveNext();
        return enm.Current;
    }

    public static int AddButtons(Rect position, SerializedProperty property, EditorButton[] buttons, int buttonHeight = 18)
    {
        position.y += EditorGUI.GetPropertyHeight(property);
        position.height = buttonHeight;
        foreach (var button in buttons)
        {
            if (GUI.Button(position, button.label)) button.onClick.Invoke(property);
            position.y += buttonHeight;
        }
        return buttonHeight * buttons.Length;
    }
}

public readonly struct EditorButton
{
    public readonly string label;
    public readonly Action<SerializedProperty> onClick;

    public EditorButton(Action<SerializedProperty> onClick)
    {
        this.onClick = onClick;
        label = onClick.Method.Name.SplitPascalCase();
    }

    public EditorButton(Action<SerializedProperty> onClick, string label) : this(onClick)
    {
        this.label = label;
    }
}