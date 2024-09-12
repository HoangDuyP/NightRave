using Pekame;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] TargetChaser targetChaser;
    [SerializeField] HouseAttacker attacker;

    private StateMachine stateMachine;
    private State moveState;
    private State attackState;

    private void Reset()
    {
        targetChaser = GetComponent<TargetChaser>();
        attacker = GetComponent<HouseAttacker>();
    }

    private void Awake()
    {
        moveState = new State()
            .SetStart(() => targetChaser.enabled = true)
            .SetEnd(() => targetChaser.enabled = false);
        attackState = new State()
            .SetStart(() => attacker.enabled = true)
            .SetEnd(() => attacker.enabled = false);
        stateMachine = new StateMachine(moveState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (!other.CompareTag("House")) return;
        stateMachine.State = attackState;

    }
}
