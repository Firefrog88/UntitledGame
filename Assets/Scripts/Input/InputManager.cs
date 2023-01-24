using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 movementInput = Vector2.zero;
    private bool jumpInput = false;
    private bool interactInput = false;
    private bool submitInput = false;

    private static InputManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("InputManager already exists. Destroying duplicate.");
            Destroy(gameObject);
        }
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            movementInput = context.ReadValue<Vector2>();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpInput = true;
            Debug.Log("Jump Input: " + jumpInput);
        }
        else if (context.canceled)
        {
            jumpInput = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactInput = true;
        }
        else if (context.canceled)
        {
            interactInput = false;
        }
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitInput = true;
        }
        else if (context.canceled)
        {
            submitInput = false;
        }
    }

    public Vector2 GetMovementInput()
    {
        return movementInput;
    }

    public bool GetJumpInput()
    {
        bool result = jumpInput;
        jumpInput = false;
        return result;
    }

    public bool GetInteractInput()
    {
        bool result = interactInput;
        interactInput = false;
        return result;
    }

    public bool GetSubmitInput()
    {
        bool result = submitInput;
        submitInput = false;
        return result;
    }

    public void RegisterSubmitInput()
    {
        submitInput = false;
    }
}
