using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //The following script is a bonus extension of the BS2DP player script.
    //If you are skipping the bonus assignment, use that script instead.

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

    private PlayerAbilities playerAb;
    private BulletGroundCheck bulletGroundCheck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0);
        playerAb = GetComponent<PlayerAbilities>();
        bulletGroundCheck = GetComponentInChildren<BulletGroundCheck>();
    }

    private void Update()
    {
        CheckHorzMovement();

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
            if (isJumping) airTime = 0;
            else airTime -= Time.deltaTime;
        }

        if (jumpBuffer > 0 && airTime > 0)
        {
            isJumping = true;
            jumpTime = 0;
            jumpBuffer = 0;
        }

        if (!Input.GetButton("Jump") || jumpTime >= buttonTime)
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer);

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTime += Time.fixedDeltaTime;
        }

        if (movement == 0) rb.velocity = new Vector2(bulletGroundCheck.GetBulletSpeed() * FreezeManager.FreezeTimer, rb.velocity.y);
        else rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAb.Restart();
        }
    }

    private void CheckHorzMovement()
    {
        movement = Input.GetAxisRaw("Horizontal");

        if (movement != 0)
        {
            playerAb.BulletDirection = Mathf.Sign(movement);
        }
    }
}
