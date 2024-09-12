using UnityEngine;

public class TargetChaser : MonoBehaviour
{
    [SerializeField] BaseMovement movement;

    private void Reset()
    {
        movement = GetComponent<BaseMovement>();
    }

    private void Update()
    {
        var deltaPos = HouseControl.Instance.transform.position - transform.position;
        movement.Move(deltaPos.normalized);
    }
}
