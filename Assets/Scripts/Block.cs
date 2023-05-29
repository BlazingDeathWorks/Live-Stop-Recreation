using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 stoppedVelocity;
    private bool timeFrozenFirstFrame = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!FreezeManager.TimeStopped)
        {
            if (timeFrozenFirstFrame)
            {
                stoppedVelocity = rb.velocity;
                rb.isKinematic = false;
            }
        }

        if (FreezeManager.TimeStopped)
        {
            rb.velocity = Vector2.zero;
            timeFrozenFirstFrame = false;
            rb.isKinematic = true;
            return;
        }

        rb.velocity = stoppedVelocity;
        timeFrozenFirstFrame = true;
    }
}
