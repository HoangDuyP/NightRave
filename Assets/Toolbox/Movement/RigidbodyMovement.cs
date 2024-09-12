using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovement : BaseMovement
{
    // fields
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Move(Vector2 input, bool isRunning = false)
    {
        base.Move(input, isRunning);

        // input
        var direction = (Vector3)input.normalized;

        // move
        var speedMultiplier = isRunning ? runSpeedMultiplier : 1;
        rb.position += speed * speedMultiplier * Time.deltaTime * direction;
    }
}