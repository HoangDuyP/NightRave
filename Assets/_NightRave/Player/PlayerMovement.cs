using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    PlayerInput playerInput;
    [SerializeField] float speedMultiplier, speed;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        playerInput.Movement.Enable();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 direction = new Vector3(playerInput.Movement.Move.ReadValue<Vector2>().x, 0f, playerInput.Movement.Move.ReadValue<Vector2>().y);
        characterController.Move(direction * speed * speedMultiplier * Time.deltaTime);
    }
}
