using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    [Header("Jumping")]
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private float buttonTime = 0.3f;
    [SerializeField] private float jumpWindow = 0.15f;
    [SerializeField] private float coyoteTime = 0.15f;

    [Header("Ground Checking")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private Rigidbody2D rb;

    private bool isGrounded;
    private bool isJumping;

    private float moveInput;
    private float jumpBuffer;
    private float jumpTime;
    private float airTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jumpBuffer = jumpWindow;
        }
        else
        {
            jumpBuffer -= Time.deltaTime;
        }

        if (isGrounded)
        {
            airTime = coyoteTime;
        }
        else
        {
            airTime -= Time.deltaTime;
        }

        if (!Input.GetButton("Jump") || jumpTime >= buttonTime)
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(.925f, .1f), 0, groundLayer);

        if (jumpBuffer > 0 && airTime > 0)
        {
            isJumping = true;
            jumpTime = 0;
            jumpBuffer = 0;
        }

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTime += Time.deltaTime;
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
