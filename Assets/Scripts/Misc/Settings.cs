using UnityEngine;

public static class Settings 
{
    [Header("Obscuring Item Fader")]
    [SerializeField] public const float fadeInSeconds = 0.25f;
    [SerializeField] public const float fadeOutSeconds = 0.15f;
    [SerializeField] public const float targetAlpha = 0.45f;

    [Header("Player Movement")]
    [SerializeField] public const float walkingSpeed = 2.666f;
    [SerializeField] public const float runningSpeed = 5.333f;

    [Header("Player Animation Parameters")]
    [SerializeField] public static int xInput;
    [SerializeField] public static int yInput;
    [SerializeField] public static int isWalking;
    [SerializeField] public static int isRunning;
    [SerializeField] public static int toolEffect;

    [SerializeField] public static int isUsingToolUp;
    [SerializeField] public static int isUsingToolDown;
    [SerializeField] public static int isUsingToolLeft;
    [SerializeField] public static int isUsingToolRight;

    [SerializeField] public static int isLiftingToolUp;
    [SerializeField] public static int isLiftingToolDown;
    [SerializeField] public static int isLiftingToolLeft;
    [SerializeField] public static int isLiftingToolRight;

    [SerializeField] public static int isPickingUp;
    [SerializeField] public static int isPickingDown;
    [SerializeField] public static int isPickingLeft;
    [SerializeField] public static int isPickingRight;

    [SerializeField] public static int isSwingingToolUp;
    [SerializeField] public static int isSwingingToolDown;
    [SerializeField] public static int isSwingingToolLeft;
    [SerializeField] public static int isSwingingToolRight;

    [Header("Shared Animation Parameters")]
    [SerializeField] public static int idleUp;
    [SerializeField] public static int idleDown;
    [SerializeField] public static int idleRight;
    [SerializeField] public static int idleLeft;

    // Static constructor
    static Settings()
    {
        // Player Animation Parameters
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        toolEffect = Animator.StringToHash("toolEffect");

        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");

        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");

        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDown = Animator.StringToHash("isPickingDown");
        isPickingLeft = Animator.StringToHash("isPickingLeft");
        isPickingRight = Animator.StringToHash("isPickingRight");

        isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");

        // Shared Animation Parameters
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");
        
    }
}
