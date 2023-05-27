using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class PlayerAbilities : MonoBehaviour
{
    private bool timeStopped;
    private GameObject[] freezables;

    [SerializeField] private GameObject bullet;
    private bool bulletShot;
    public float bulletDirection;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TimeFreeze();
        }

        if (bullet.gameObject.activeInHierarchy == false)
        {
            bulletShot = false;
            bullet.transform.parent = transform;
        }

        if (Input.GetKeyDown(KeyCode.J) && bulletShot == false)
        {
            Shoot();
        }
    }

    void TimeFreeze()
    {
        freezables = GameObject.FindGameObjectsWithTag("Freezable");

        foreach (GameObject freezable in freezables)
        {
            Rigidbody2D rb = freezable.GetComponent<Rigidbody2D>();

            Vector2 vel2D = rb.velocity;

            if (!timeStopped)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                timeStopped = true;
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.velocity = vel2D;
                timeStopped = false;
            }
        }
    }

    void Shoot()
    {
        bullet.SetActive(true);
        bullet.transform.position = new Vector2(transform.position.x + (bulletDirection * 0.75f), transform.position.y);
        bullet.transform.rotation = Quaternion.identity;
        bullet.GetComponent<Bullet>().speed *= bulletDirection;
        bullet.transform.parent = null;
        bulletShot = true;
    }
}
