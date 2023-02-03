using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 movementInput = Vector2.zero;
    private bool walkInput = false;
    private bool jumpInput = false;
    private bool interactInput = false;
    private bool submitInput = false;
    private bool inventoryInput = false;

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

    public void OnWalk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            walkInput = true;
        }
        else if (context.canceled)
        {
            walkInput = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpInput = true;
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

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inventoryInput = true;
        }
        else if (context.canceled)
        {
            inventoryInput = false;
        }
    }

    public Vector2 GetMovementInput()
    {
        return movementInput;
    }

    public bool GetWalkInput()
    {
        return walkInput;
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

    public bool GetInventoryInput()
    {
        bool result = inventoryInput;
        inventoryInput = false;
        return result;
    }

    public void RegisterSubmitInput()
    {
        submitInput = false;
    }
}
