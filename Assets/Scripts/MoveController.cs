using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float xInput;

    [Header("Collision check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    private bool facingRight = true;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimationControllers();
        CollisionChecks();
        FlipController();

        xInput = Input.GetAxisRaw("Horizontal");

        Movement();

        if(Input.GetKeyDown(KeyCode.Space) )
            Jump();

        
    }

    private void AnimationControllers()
    {
        animator.SetFloat("xVelocity", rigidBody.velocity.x);
        animator.SetFloat("yVelocity", rigidBody.velocity.y);
        animator.SetBool("isGrounded", isGrounded);

    }
 
    private void Jump()
    {
        if(isGrounded)
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }

    private void Movement()
    {
        rigidBody.velocity = new Vector2(xInput * moveSpeed, rigidBody.velocity.y);

    }

    private void FlipController()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x && facingRight)
            Flip();
        else if (mousePos.x > transform.position.x && !facingRight)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }


}
