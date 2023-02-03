using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : SingletonMonobehaviour<Player>
{
    // Movement Parameters
    private float xInput;
    private float yInput;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isWalking;
    private bool isRunning;

    private ToolEffect toolEffect = ToolEffect.none;

    private bool isUsingToolUp;
    private bool isUsingToolDown;
    private bool isUsingToolLeft;
    private bool isUsingToolRight;

    private bool isLiftingToolUp;
    private bool isLiftingToolDown;
    private bool isLiftingToolLeft;
    private bool isLiftingToolRight;

    private bool isPickingUp;
    private bool isPickingDown;
    private bool isPickingLeft;
    private bool isPickingRight;

    private bool isSwingingToolUp;
    private bool isSwingingToolDown;
    private bool isSwingingToolLeft;
    private bool isSwingingToolRight;

    private Rigidbody2D rigidBody2D;

    private Direction playerDirection;

    private float movementSpeed;

    private bool playerInputDisabled = false;

    public bool PlayerInputDisabled { get => playerInputDisabled; set => playerInputDisabled = value; }

    protected override void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region Player Input

        ResetAnimationTriggers();

        PlayerMovementInput();

        PlayerWalkInput();

        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect, isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown, isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown, isPickingRight, isPickingLeft, isPickingUp, isPickingDown, isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown, false, false, false, false);

        #endregion
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);
        rigidBody2D.MovePosition(rigidBody2D.position + move);
    }

    private void ResetAnimationTriggers()
    {
        toolEffect = ToolEffect.none;

        isUsingToolUp = false;
        isUsingToolDown = false;
        isUsingToolLeft = false;
        isUsingToolRight = false;

        isLiftingToolUp = false;
        isLiftingToolDown = false;
        isLiftingToolLeft = false;
        isLiftingToolRight = false;

        isPickingUp = false;
        isPickingDown = false;
        isPickingLeft = false;
        isPickingRight = false;

        isSwingingToolUp = false;
        isSwingingToolDown = false;
        isSwingingToolLeft = false;
        isSwingingToolRight = false;
    }

    private void PlayerMovementInput()
    {
        Vector2 inputVector = InputManager.GetInstance().GetMovementInput();

        xInput = inputVector.x;
        yInput = inputVector.y;

        if (xInput != 0 && yInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }
        
        if (xInput != 0 || yInput != 0)
        {
            isWalking = false;
            isRunning = true;
            isIdle = false;

            movementSpeed = Settings.runningSpeed;

            if (xInput < 0)
            {
                playerDirection = Direction.left;
            }
            else if (xInput > 0)
            {
                playerDirection = Direction.right;
            }
            else if (yInput < 0)
            {
                playerDirection = Direction.down;
            }
            else if (yInput > 0)
            {
                playerDirection = Direction.up;
            }
            else
            {
                playerDirection = Direction.up;
            }
        }
        else if (xInput == 0 && yInput == 0)
        {
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }
    }

    private void PlayerWalkInput()
    {
        bool walkInput = InputManager.GetInstance().GetWalkInput();
        if (walkInput)
        {
            isWalking = true;
            isRunning = false;
            isIdle = false;

            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            isWalking = false;
            isRunning = true;
            isIdle = false;

            movementSpeed = Settings.runningSpeed;
        }
    }
}
