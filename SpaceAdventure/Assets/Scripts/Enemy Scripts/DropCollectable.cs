using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollectable : MonoBehaviour
{
    [SerializeField] private GameObject[] colletables;

    public void CheckToSpawnCollectable()
    {
        if (Random.Range(0, 2) > 0)
        {
            Instantiate(colletables[Random.Range(0, colletables.Length)], transform.position, Quaternion.identity);
        }
    }
}
