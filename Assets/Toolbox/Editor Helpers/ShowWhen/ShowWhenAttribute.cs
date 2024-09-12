using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ShowWhenAttribute : PropertyAttribute
{
    public string ConditionField = "";
    public bool HideInInspector = true;

    public ShowWhenAttribute(string conditionalSourceField)
    {
        ConditionField = conditionalSourceField;
    }

    public ShowWhenAttribute(string conditionalSourceField, bool hideInInspector)
    {
        ConditionField = conditionalSourceField;
        HideInInspector = hideInInspector;
    }
}