using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManage;
    Rigidbody rigidBody;
    Vector3 moveDirection;
    Transform cameraOjb;

    private void Awake()
    {
        inputManage = GetComponent<InputManager>();
        rigidBody = GetComponent<Rigidbody>();
        cameraOjb = Camera.main.transform;
    }

    public void HandleAllMove()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {

    }

    public void HandleRotation()
    {

    }
}
