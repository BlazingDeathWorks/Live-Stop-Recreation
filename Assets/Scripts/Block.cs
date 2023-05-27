using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 stoppedVelocity;
    private bool timeFrozenFirstFrame = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!FreezeManager.TimeStopped)
        {
            if (timeFrozenFirstFrame) stoppedVelocity = rb.velocity;
        }

        if (FreezeManager.TimeStopped)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            timeFrozenFirstFrame = false;
            return;
        }

        rb.gravityScale = 1;
        rb.velocity = stoppedVelocity;
        timeFrozenFirstFrame = true;
    }
}
