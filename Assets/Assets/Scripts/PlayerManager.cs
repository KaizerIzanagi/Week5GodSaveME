using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [Header("Components")]
    //Player Game Object
    public GameObject player;
    public Rigidbody rigidBody;
    public Animator playerAnim;
    [Header("Scripts")]
    //PlayerScripts
    public InputManager inputManager;
    public PlayerLocomotion locomotion;
    public PlayerAnimation playerAnimation;
    //Player Stats
    [Header("Player Stats")]
    [Range(0, 100)]
    public float movementSpeed;
    [Range(0, 100)]
    public float sprintSpeed;
    [Range(0, 100)]
    public float walkSpeed;
    [Range(0, 1)]
    public float rotationSpeed;
    [Header("Action Status")]
    public bool isSprinting;
    public bool isWalking;
    public bool isJumping;


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        inputManager = player.GetComponent<InputManager>();
        locomotion = player.GetComponent<PlayerLocomotion>();
        rigidBody = player.GetComponent<Rigidbody>();
        playerAnimation = player.GetComponent<PlayerAnimation>();
        playerAnim = player.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        inputManager.HandleAllInput();
    }

    private void FixedUpdate()
    {
        locomotion.HandleAllMove();
    }
}
