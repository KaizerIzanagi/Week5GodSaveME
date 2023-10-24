using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputActions playerControls;
    private Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    public float moveAmount;
    public bool sprint_Input;
    public bool walk_Input;
    public bool run_Input;
    public bool jump_Input;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new InputActions();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.Sprint.performed += i => sprint_Input = true;
            playerControls.PlayerActions.Sprint.canceled += i => sprint_Input = false;
            playerControls.PlayerActions.Walk.performed += i => walk_Input = true;
            playerControls.PlayerActions.Walk.canceled += i => walk_Input = false;
            playerControls.PlayerActions.Run.performed += i => run_Input = true;
            playerControls.PlayerActions.Run.canceled += i => run_Input = false;
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInput()
    {
        HandleMoveInput();
        HandleSprinting();
        HandleWalking();
        HandleRunning();
    }

    private void HandleMoveInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        PlayerManager.Instance.playerAnimation.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleSprinting()
    {
        if (sprint_Input && moveAmount > 1.5)
        {
            PlayerManager.Instance.isSprinting = true;

        }
        else
        {
            PlayerManager.Instance.isSprinting = false;
        }
    }

    private void HandleWalking()
    {
        if (walk_Input && moveAmount > 0)
        {
            PlayerManager.Instance.isWalking = true;

        }
        else
        {
            PlayerManager.Instance.isWalking = false;
        }
    }

    private void HandleRunning()
    {
        if (run_Input && moveAmount > 1)
        {
            PlayerManager.Instance.isRunning = true;

        }
        else
        {
            PlayerManager.Instance.isRunning = false;
        }
    }
}
