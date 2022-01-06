using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private float min_X, max_X;
    [SerializeField] int minSpawnNumber = 1, maxSpawnNumber = 5;

    [SerializeField] private float minSpawnIntervals = 4f, maxSpawnIntervals = 10f;
    private int randSpawnNum;
    private Vector3 randSpawnPos;

    private void Start()
    {
        Invoke("SpawnMeteors", Random.Range(minSpawnIntervals, maxSpawnIntervals));
    }



    void SpawnMeteors()
    {
        randSpawnNum = Random.Range(minSpawnNumber, maxSpawnNumber);

        for(int i = 0; i < randSpawnNum; i++)
        {
            randSpawnPos = new Vector3(Random.Range(min_X, max_X), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPos, Quaternion.identity);
        }

        Invoke("SpawnMeteors", Random.Range(minSpawnIntervals, maxSpawnIntervals));
    }
}
