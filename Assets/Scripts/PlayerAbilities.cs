using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAbilities : MonoBehaviour
{
    private bool timeStopped;
    private GameObject[] freezables;
    private Vector2 vel2D;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            TimeFreeze();
        }
    }

    void TimeFreeze()
    {
        freezables = GameObject.FindGameObjectsWithTag("Freezable");

        foreach (GameObject freezable in freezables)
        {
            Rigidbody2D rb = freezable.GetComponent<Rigidbody2D>();

            if (!timeStopped)
            {
                vel2D = rb.velocity;
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
}
