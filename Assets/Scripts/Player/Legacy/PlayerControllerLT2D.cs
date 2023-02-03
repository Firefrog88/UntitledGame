using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerLT2D : MonoBehaviour, IDataPersistence
{
    [Header("Components")]    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Movement")]
    private float lateralMovement;
    private float speed = 8f;
    private float jumpForce = 16f;
    private bool isGrounded;
    private bool facingRight = true;

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        if (InventoryManager.GetInstance().inventoryOpen)
        {
            Debug.Log("(Inventory open)");
            if(InputManager.GetInstance().GetInventoryInput())
            {
                InventoryManager.GetInstance().ExitInventory();
            }
            else
            {
                return;
            }
        }
        
        Debug.Log("Accesing handlers");
        HandleMove();
        HandleJump();
        HandleInventory();

        if((!facingRight && lateralMovement > 0f) || (facingRight && lateralMovement < 0f))
        {
            Flip();
        }
    }

    public void HandleMove()
    {
        lateralMovement = InputManager.GetInstance().GetMovementInput().x;
        rb.velocity = new Vector2(lateralMovement * speed, rb.velocity.y);
    }

    public void HandleInventory()
    {
        if (InputManager.GetInstance().GetInventoryInput())
        {
            InventoryManager.GetInstance().EnterInventory();
        }
    }

    public void HandleJump()
    {
        bool jumpPressed = InputManager.GetInstance().GetJumpInput();
        if (jumpPressed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (jumpPressed && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
