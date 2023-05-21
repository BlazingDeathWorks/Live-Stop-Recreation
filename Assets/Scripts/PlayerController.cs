/*
    1- Basic Movement System
    2- Check if character is grounded or not (if it is touching the floor)
    3- Jump when the W key or Up arrow key is pressed and the character is on the ground
*/
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;

    private Collider2D playerCollider;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // Move the character horizontally (#1)

        isGrounded = IsGrounded(); // Check if the character is on the ground (#2)
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded) //#3
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        bool isTouchingGround = playerCollider.IsTouchingLayers(groundLayer);
        return isTouchingGround;
    }
}
