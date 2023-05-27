using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class BulletGroundCheck : MonoBehaviour
{
    private bool onBullet;
    private Bullet bullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;
        bullet = collision.GetComponent<Bullet>();
        onBullet = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;
        onBullet = false;
    }

    public float GetBulletSpeed()
    {
        if (!onBullet) return 0;
        return bullet.Speed;
    }
}
