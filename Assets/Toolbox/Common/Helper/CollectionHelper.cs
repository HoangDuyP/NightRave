using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CollectionHelper
{
    public static T RandomElement<T>(this IEnumerable<T> enumerable)
    {
        int index = Random.Range(0, enumerable.Count());
        return enumerable.ElementAt(index);
    }

    public static IEnumerable<T> RandomElements<T>(this IEnumerable<T> enumerable, int count)
    {
        return enumerable.OrderBy(x => Random.value).Take(count);
    }

    /// <summary>
    /// Shuffle the list in place using the Fisher-Yates method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int pos = Random.Range(i, list.Count);
            var temp = list[i];
            list[i] = list[pos];
            list[pos] = temp;
        }
    }
}
