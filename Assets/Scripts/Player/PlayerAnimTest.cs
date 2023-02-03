using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimTest : MonoBehaviour
{
    [SerializeField] private float inputX;
    [SerializeField] private float inputY;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isIdle;
    [SerializeField] private bool isCarrying;
    [SerializeField] private ToolEffect toolEffect;

    [SerializeField] private bool isUsingToolUp;
    [SerializeField] private bool isUsingToolDown;
    [SerializeField] private bool isUsingToolLeft;
    [SerializeField] private bool isUsingToolRight;

    [SerializeField] private bool isLiftingToolUp;
    [SerializeField] private bool isLiftingToolDown;
    [SerializeField] private bool isLiftingToolLeft;
    [SerializeField] private bool isLiftingToolRight;

    [SerializeField] private bool isPickingUp;
    [SerializeField] private bool isPickingDown;
    [SerializeField] private bool isPickingLeft;
    [SerializeField] private bool isPickingRight;

    [SerializeField] private bool isSwingingToolUp;
    [SerializeField] private bool isSwingingToolDown;
    [SerializeField] private bool isSwingingToolLeft;
    [SerializeField] private bool isSwingingToolRight;

    [SerializeField] private bool idleUp;
    [SerializeField] private bool idleDown;
    [SerializeField] private bool idleLeft;
    [SerializeField] private bool idleRight;

    private void Update()
    {
        EventHandler.CallMovementEvent(inputX, inputY, isWalking, isRunning, isIdle, isCarrying, toolEffect, isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown, isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown, isPickingRight, isPickingLeft, isPickingUp, isPickingDown, isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown, idleRight, idleLeft, idleUp, idleDown);
    }
}
