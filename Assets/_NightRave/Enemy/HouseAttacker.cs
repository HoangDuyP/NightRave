using UnityEngine;

public class HouseAttacker : MonoBehaviour
{
    [SerializeField] float damage = 2;

    public void Attack()
    {
        HouseControl.Instance.GetComponentInChildren<Health>().Value -= damage;
    }

    private void OnEnable()
    {
        Attack();
    }
}
