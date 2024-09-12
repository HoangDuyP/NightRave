using System.Collections.Generic;
using UnityEngine;

public class SimplePool<T> where T : MonoBehaviour
{
    public readonly Transform parent;
    private readonly T prototype;
    private readonly Queue<T> freeObjects;
    private readonly List<T> usedObjects;

    public SimplePool(T prototype)
    {
        this.prototype = prototype;
        freeObjects = new Queue<T>();
        usedObjects = new List<T>();
    }

    public SimplePool(T prototype, string name) : this(prototype) => parent = new GameObject(name).transform;

    public SimplePool(T prototype, Transform poolParent) : this(prototype) => parent = poolParent;

    public T Spawn()
    {
        if (freeObjects.Count == 0) freeObjects.Enqueue(Object.Instantiate(prototype, parent));
        var obj = freeObjects.Dequeue();
        obj.gameObject.SetActive(true);
        usedObjects.Add(obj);
        return obj;
    }

    public T Spawn(Vector3 position, Quaternion rotation)
    {
        var obj = Spawn();
        obj.transform.SetPositionAndRotation(position, rotation);
        return obj;
    }

    public void Despawn(T obj)
    {
        obj.gameObject.SetActive(false);
        freeObjects.Enqueue(obj);
        usedObjects.Remove(obj);
    }

    public void DespawnAll()
    {
        while (usedObjects.Count > 0) Despawn(usedObjects[0]);
    }

    public void Destroy() => Object.Destroy(parent.gameObject);
}
