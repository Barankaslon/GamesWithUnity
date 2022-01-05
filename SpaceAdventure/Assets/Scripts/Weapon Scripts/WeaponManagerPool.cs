using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerPool : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private List<GameObject> projectilePool = new List<GameObject>();
    [SerializeField] private KeyCode keyToPressToShoot;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float shootWaitTime = 0.2f;
    [SerializeField] private bool isEnemy;

    private GameObject projectileHolder;
    private bool _projectileSpawned;
    private float _shootTimer;
    private bool _canShoot;

    private void Awake()
    {
        if(isEnemy)
        {
            projectileHolder = GameObject.FindWithTag(TagManager.ENEMY_PROJECTILE_HOLDER_TAG);
            ResetShootingTimer();
        }
        else
        {
            projectileHolder = GameObject.FindWithTag(TagManager.PLAYER_PROJECTILE_HOLDER_TAG);
        }
    }

    private void Update() 
    {
        if(Time.time > _shootTimer)
            _canShoot = true;

        HandlePlayerShooting();
        HandleEnemyShooting();
    }

    void HandlePlayerShooting()
    {
        if(!_canShoot || isEnemy)
            return;

        if(Input.GetKeyDown(keyToPressToShoot))
        {
            GetObjectFromPoolOrSpawnANewOne();
            ResetShootingTimer();
        }
    }

    void GetObjectFromPoolOrSpawnANewOne()
    {
        for(int i = 0; i < projectilePool.Count; i++)
        {
            if(!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position = projectileSpawnPoint.position;
                projectilePool[i].SetActive(true);

                _projectileSpawned = true;
                break;
            }
            else
            {
                _projectileSpawned = false;
            }
        }

        if(!_projectileSpawned)
        {
            GameObject newProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);

            projectilePool.Add(newProjectile);

            newProjectile.transform.SetParent(projectileHolder.transform);

            _projectileSpawned = true;
        }
    }

    void ResetShootingTimer()
    {
        _canShoot = false;

        if(isEnemy)
        {
            _shootTimer = Time.time + Random.Range(shootWaitTime, (shootWaitTime + 1f));
        }
        else
        {
            _shootTimer = Time.time + shootWaitTime;
        }
    }

    void HandleEnemyShooting()
    {
        if(!isEnemy || !_canShoot)
            return;
        
        ResetShootingTimer();
        GetObjectFromPoolOrSpawnANewOne();
    }

}
