using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float max;

    // props
    public float Value
    {
        get => value;
        set
        {
            value = Mathf.Clamp(value, 0, max);
            if (value == this.value) return;
            this.value = value;
        }
    }

    // fields
    private float value;

    private void Awake()
    {
        value = max;
    }
}
