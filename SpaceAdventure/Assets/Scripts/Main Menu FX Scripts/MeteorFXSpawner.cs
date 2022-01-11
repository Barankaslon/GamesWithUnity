using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private float minSpawnTime = 3f, maxSpawnTime = 7f;
    [SerializeField] private float min_X, max_X;
    [SerializeField] private bool moveDown;

    private float spawnTimer;

    private Vector3 spawnPos;

    private int spawnNum;


    private void Start()
    {
        spawnTimer = Time.deltaTime + Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Update()
    {
        if(Time.time > spawnTimer)
            SpawnMeteor();
        
    }

    void SpawnMeteor()
    {
        spawnNum = Random.Range(1, 6);

        for(int i = 0; i < spawnNum; i++)
        {
            spawnPos = new Vector3(Random.Range(min_X, max_X), transform.position.y, 0f);

            GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)], spawnPos, Quaternion.identity);

            if(moveDown)
                newMeteor.GetComponent<MeteorFXMovement>().moveDown = true;

            newMeteor.transform.SetParent(transform);
        }

        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }
}
