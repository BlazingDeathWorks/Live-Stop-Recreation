using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //This script is an edited version of the BS2DP script to include bonuses.
    //If you are not doing the bonus assignment, no edits need to be made.

    [SerializeField] private float speed = 4f;
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private Vector2 spawnPoint;

    [Header("Bonus Jumping Variables")]
    [SerializeField] private float buttonTime = 0.3f;
    [SerializeField] private float jumpWindow = 0.15f;
    [SerializeField] private float coyoteTime = 0.15f;

    private float movement;
    private bool isGrounded;
    private bool isJumping;

    private Rigidbody2D rb;
    private Transform groundCheck;

    private float jumpBuffer;
    private float jumpTime;
    private float airTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0);
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

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
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer);

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

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = spawnPoint;
        }
    }
}
