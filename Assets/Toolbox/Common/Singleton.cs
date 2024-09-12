using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;
    protected void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            return;
        }
        Instance = GetComponent<T>();
    }
    //protected void OnDestroy()
    //{
    //    if (Instance == this) Instance = null;
    //}
}
