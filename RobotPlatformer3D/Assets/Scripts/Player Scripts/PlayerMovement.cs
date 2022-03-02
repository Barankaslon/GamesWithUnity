using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float movementnSpeed = 5f;

    [Header("Gravity Options")]
    [SerializeField] [Range(-80f, 0f)] private float gravityScale = -40;
    [SerializeField] [Range(2f, 30f)] private float jumpHeight = 5;

    [Header("Ground Options")]
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Button Options")]
    [SerializeField] private string jumpButton = "Jump";

    private Vector3 movementDirection;
    private Vector3 verticalVelocity;
    private bool _canDoubleJump;
    private bool _isGrounded;

    public bool CanDoubleJump
    {
        get
        { return _canDoubleJump; }
        set
        {
            { _canDoubleJump = value; }
        }
    }

        public bool IsGrounded
    {
        get
        { return _isGrounded; }
        set
        {
            { _isGrounded = value; }
        }
    }

    private PlayerAnimation playerAnim;

    [SerializeField] private GameObject model;
    private Camera mainCam;
    [SerializeField] private float rotateSpeed = 5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        mainCam = Camera.main;
        playerAnim = GetComponent<PlayerAnimation>();
    }
}
