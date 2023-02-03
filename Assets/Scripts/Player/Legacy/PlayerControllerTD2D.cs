using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerTD2D : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    private Vector2 topDownMovement;

    [Header("Movement parameters")]
    [SerializeField] private float speed = 8f;

    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        if (InventoryManager.GetInstance().inventoryOpen)
        {
            if(InputManager.GetInstance().GetInventoryInput())
            {
                InventoryManager.GetInstance().ExitInventory();
            }
            else
            {
                return;
            }
        }

        HandleMove();
        HandleInventory();
    }

    public void HandleMove()
    {
        topDownMovement = InputManager.GetInstance().GetMovementInput();
        rb.velocity = topDownMovement * speed;
    }

    public void HandleInventory()
    {
        if (InputManager.GetInstance().GetInventoryInput())
        {
            InventoryManager.GetInstance().EnterInventory();
        }
    }
}