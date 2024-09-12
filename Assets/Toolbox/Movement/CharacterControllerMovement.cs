using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : BaseMovement
{
    enum Axis
    {
        Y, Z
    }

    [SerializeField] Axis verticalAxis;

    // fields
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.enabled = true;
    }

    public override void Move(Vector2 input, bool isRunning = false)
    {
        base.Move(input, isRunning);

        // input
        var hinput = input.x;
        var vinput = input.y;
        var direction = verticalAxis switch
        {
            Axis.Y => new Vector3(hinput, vinput, 0),
            Axis.Z => new Vector3(hinput, 0, vinput),
            _ => throw new NotImplementedException(),
        };

        // move
        var speedMultiplier = isRunning ? runSpeedMultiplier : 1;
        controller.Move(speed * speedMultiplier * Time.deltaTime * direction);
    }
}