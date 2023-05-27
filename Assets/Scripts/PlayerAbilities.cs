using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAbilities : MonoBehaviour
{
    private GameObject[] freezables;

    [SerializeField] private GameObject bullet;
    private bool bulletShot;
    public float bulletDirection;

    void Update()
    {
        //Reset
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //Freeze Time
        if (Input.GetKeyDown(KeyCode.K))
        {
            FreezeManager.FreezeTime();
        }

        if (bullet.gameObject.activeInHierarchy == false)
        {
            bulletShot = false;
            bullet.transform.parent = transform;
        }

        //Shoot
        if (Input.GetKeyDown(KeyCode.J) && bulletShot == false)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        bullet.SetActive(true);
        bullet.transform.position = new Vector2(transform.position.x + (bulletDirection * 0.75f), transform.position.y);
        bullet.transform.rotation = Quaternion.identity;
        bullet.GetComponent<Bullet>().Speed *= bulletDirection;
        bullet.transform.parent = null;
        bulletShot = true;
    }
}
