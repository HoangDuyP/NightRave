using System;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float runSpeedMultiplier = 2;

    // props
    public float RunMultiplier => runSpeedMultiplier;

    // events
    public event Action<Vector2, bool> OnMove;

    public virtual void Move(Vector2 input, bool isRunning = false) => OnMove?.Invoke(input, isRunning);
}

interface IMovementEvent
{
    
}

