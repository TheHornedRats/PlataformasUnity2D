using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true;
    private bool isGrounded;
    private int jumpCount;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpCount = maxJumps;
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded) jumpCount = maxJumps;

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }

        
        if (moveInput > 0 && !facingRight) Flip();
        else if (moveInput < 0 && facingRight) Flip();

        
        animator.SetBool("Walk", moveInput != 0);
        animator.SetBool("Jump", !isGrounded);
    }

    public Transform attackRoot; 

    void Flip()
    {
        facingRight = !facingRight;

      
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        
        Vector3 rootScale = attackRoot.localScale;
        rootScale.x *= -1;
        attackRoot.localScale = rootScale;
    }


    public bool IsFacingRight()
    {
        return facingRight;
    }
}
