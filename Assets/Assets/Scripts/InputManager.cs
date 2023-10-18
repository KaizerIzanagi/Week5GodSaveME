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

    private void OnEnable()
    {
       if (playerControls == null)
        {
            playerControls = new InputActions();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.Sprint.performed += i => sprint_Input = true;
            playerControls.PlayerActions.Sprint.canceled += i => sprint_Input = false;
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
        if (sprint_Input && moveAmount > 0.5)
        {
            PlayerManager.Instance.isSprinting = true;
        
        }
        else
        {
            PlayerManager.Instance.isSprinting = false;
        }
    }
}
