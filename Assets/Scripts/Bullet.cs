using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private float originalSpeed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        originalSpeed = Speed;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Speed * FreezeManager.FreezeTimer, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            gameObject.SetActive(false);
            Speed = originalSpeed;
        }
    }
}
