using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementTD2D : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 topDownMovement;
    private float speed = 8f;

    private bool interactPressed = false;
    private bool submitPressed = false;

    void Update()
    {
        rb.velocity = topDownMovement * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        topDownMovement = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else
        {
            interactPressed = false;
        }
    }

    public void Submit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else
        {
            submitPressed = false;
        }
    }

    public bool GetInteractPressed()
    {
        return interactPressed;
    }

    public bool GetSubmitPressed()
    {
        return submitPressed;
    }
}
