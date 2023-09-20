using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputActions playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    

    private void OnEnable()
    {
       if (playerControls == null)
        {
            playerControls = new InputActions();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
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
    }

    private void HandleMoveInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }
}
