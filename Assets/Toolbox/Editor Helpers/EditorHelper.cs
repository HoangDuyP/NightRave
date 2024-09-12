#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class EditorHelper
{
    public static void ShowTypesMenu<T>(List<T> list, bool includeBaseClass = false, Action<T> onSelected = null)
    {
#if UNITY_EDITOR
        var types = Helper.GetAllTypesDerivedFrom<T>();
        if (includeBaseClass) types = Enumerable.Concat(new[] { typeof(T) }, types);
        GenericMenu menu = new();
        foreach (var type in types)
            menu.AddItem(new GUIContent(type.Name), false, () =>
            {
                T instance = (T)Activator.CreateInstance(type);
                list.Add(instance);
                onSelected?.Invoke(instance);
            });
        menu.ShowAsContext();
#endif
    }
}
