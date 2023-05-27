using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class BulletGroundCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;
        transform.root.SetParent(collision.transform);
        Debug.Log("Hello");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;
        transform.root.SetParent(null);
        Debug.Log("Hi");
    }
}
