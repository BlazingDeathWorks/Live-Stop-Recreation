using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAbilities : MonoBehaviour
{
    public float BulletDirection;
    [SerializeField] private GameObject bullet;
    private bool bulletShot;

    void Update()
    {
        //Reset
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
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
        bullet.transform.position = new Vector2(transform.position.x + (BulletDirection * 0.75f), transform.position.y);
        bullet.transform.rotation = Quaternion.identity;
        bullet.GetComponent<Bullet>().Speed *= BulletDirection;
        bullet.transform.parent = null;
        bulletShot = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
