using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Transform blockSpawnPoint;
    private GameObject block;
    private bool blockActive;

    private void Awake()
    {
        block = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (block.activeInHierarchy == false)
        {
            blockActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!blockActive)
        {
            block.SetActive(true);
            block.transform.position = blockSpawnPoint.position;
            block.transform.rotation = Quaternion.identity;
            blockActive = true;
        }
    }
}
