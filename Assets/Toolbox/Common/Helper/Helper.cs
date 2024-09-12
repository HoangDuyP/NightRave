using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Helper
{
    public static void RepeatAction(int repeatCount, Action action)
    {
        for (int i = 0; i < repeatCount; i++) action();
    }

    public static void RepeatAction(int repeatCount, Action<int> action)
    {
        for (int i = 0; i < repeatCount; i++) action(i);
    }

    public static void DelayAction(float delay, Action action)
    {
        new Thread(new ThreadStart(() =>
        {
            Thread.Sleep((int)(delay * 1000));
            action?.Invoke();
        })).Start();
    }

    public static Vector2 GetRandomPoint(this Rect rect) => new Vector2(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax));

    public static bool Chance(float rate) => Random.value < rate;

    public static float Remap(this float value, float valueRangeMin, float valueRangeMax, float newRangeMin, float newRangeMax)
    {
        return (value - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin) + newRangeMin;
    }

    public static IEnumerable<Type> GetAllTypesDerivedFrom<T>()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(typeof(T)));
    }

    public static string SplitPascalCase(this string str) => Regex.Replace(str, "(\\B[A-Z])", " $1");
}
