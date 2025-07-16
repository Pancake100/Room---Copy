using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    private CharacterController controller;
    private Vector2 inputMove;
    private Transform cameraTransform;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 move = cameraTransform.right * inputMove.x + cameraTransform.forward * inputMove.y;
        move.y = 0f;
        controller.Move(move * speed * Time.deltaTime);
    }
}



