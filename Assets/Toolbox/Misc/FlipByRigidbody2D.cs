using UnityEngine;

public class FlipByRigidbody2D : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;

    private void Update()
    {
        var vel = rb.velocity;
        if (vel.magnitude > 0) spriteRenderer.flipX = vel.x < 0;
    }
}
