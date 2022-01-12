using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;

    [SerializeField] private List<GameObject> spawnedMeteors = new List<GameObject>();
    [SerializeField] private float minSpawnTime = 3f, maxSpawnTime = 7f;
    [SerializeField] private float min_X, max_X;
    [SerializeField] private bool moveDown;

    private float spawnTimer;

    private Vector3 spawnPos;

    private int spawnNum;

    private int activatedMeteors;


    private void Start()
    {
        spawnTimer = Time.deltaTime + Random.Range(minSpawnTime, maxSpawnTime);
        SpawnInitialNumberOfMeteors(40);
    }

    private void Update()
    {
        if(Time.time > spawnTimer)
            SpawnMeteorsFromPool();
        
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

    //Pooling

    void SpawnInitialNumberOfMeteors(int spawnNum)
    {
        for(int i = 0; i < spawnNum; i++)
        {
            GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)]);
            newMeteor.transform.SetParent(transform);
            newMeteor.SetActive(false);
            spawnedMeteors.Add(newMeteor);
        }
    }

    void SpawnMeteorsFromPool()
    {
        spawnNum = Random.Range(1, 6);
        activatedMeteors = 0;

        for(int i = 0; i < spawnedMeteors.Count; i++)
        {
            if(!spawnedMeteors[i].activeInHierarchy)
            {
                spawnPos = new Vector3(Random.Range(min_X, max_X), transform.position.y, 0f);

                    spawnedMeteors[i].SetActive(true);
                    spawnedMeteors[i].transform.position = spawnPos;

                    if(moveDown)
                        spawnedMeteors[i].GetComponent<MeteorFXMovement>().moveDown = true;
                    activatedMeteors++;

                    if(activatedMeteors == spawnNum)
                        break;
            }
        }
        
        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

}
