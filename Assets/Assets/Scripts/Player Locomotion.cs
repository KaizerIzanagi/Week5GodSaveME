    using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Vector3 moveDirection;
    Transform cameraOjb;

    private void Awake()
    {
        cameraOjb = Camera.main.transform;
    }

    public void HandleAllMove()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraOjb.forward * PlayerManager.Instance.inputManager.verticalInput;
        moveDirection = moveDirection + cameraOjb.right * PlayerManager.Instance.inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (PlayerManager.Instance.isSprinting)
        {
            moveDirection *= PlayerManager.Instance.sprintSpeed;
        }
        else
        {
            moveDirection *= PlayerManager.Instance.movementSpeed;
        }


        moveDirection *= PlayerManager.Instance.movementSpeed;
        Vector3 movementVelocity = moveDirection;
        PlayerManager.Instance.rigidBody.velocity = movementVelocity;  
    }

    public void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraOjb.forward * PlayerManager.Instance.inputManager.verticalInput;
        targetDirection = targetDirection + cameraOjb.right * PlayerManager.Instance.inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;
        
        //line that makes the rotation the same as direction
        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }


        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerManager.Instance.rotationSpeed);
                
        transform.rotation = playerRotation;
    }
}
