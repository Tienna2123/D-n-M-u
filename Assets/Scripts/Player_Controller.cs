using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public GameObject arrowPrefab; // Prefab của mũi tên
    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Animator animator;

    private bool canDoubleJump;
    private int jumpCount = 0;
    private int maxJumps = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

       
        

        // Cập nhật tham số Speed cho Animator
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Cập nhật tham số VerticalSpeed cho Animator
        animator.SetFloat("VerticalSpeed", rb.velocity.y);

        // Cập nhật tham số IsGrounded cho Animator
        animator.SetBool("IsGrounded", IsGrounded());

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || (jumpCount < maxJumps && canDoubleJump))
            {
                Jump();
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (IsGrounded())
        {
            jumpCount = 0;
            canDoubleJump = true;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpCount = 1; // Đặt jumpCount thành 1 khi nhảy lần đầu
        }
        else if (canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpCount = 2; // Đặt jumpCount thành 2 khi double jump
            canDoubleJump = false; // Không cho phép double jump nữa
        }

        // Cập nhật trạng thái Animator
        if (jumpCount == 1)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsDoubleJumping", false);
        }
        else if (jumpCount == 2)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJumping", true);
        }
    }

    private bool IsGrounded()
    {
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        return grounded;
    }

   

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            
        }
    }

}
