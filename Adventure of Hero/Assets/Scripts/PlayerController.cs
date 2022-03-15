using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    public float runSpeed;
    public Animator playerAnim;
    [SerializeField] private Rigidbody2D playerRB;
    [Header("Jump")]
    public float jumpForce;
    public Transform groundcheck;
    private bool isGrounded;
    public LayerMask groundFloor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, playerRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, groundFloor);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
    }
}
