using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerLT2D : MonoBehaviour
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

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        
        HandleMove();
        HandleJump();

        if((!facingRight && lateralMovement > 0f) || (facingRight && lateralMovement < 0f))
        {
            Flip();
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

    public void HandleMove()
    {
        lateralMovement = InputManager.GetInstance().GetMovementInput().x;
        rb.velocity = new Vector2(lateralMovement * speed, rb.velocity.y);
    }
}
