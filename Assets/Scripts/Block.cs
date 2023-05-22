using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float yLimit;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yLimit)
        {
            gameObject.SetActive(false);
        }
    }
}
