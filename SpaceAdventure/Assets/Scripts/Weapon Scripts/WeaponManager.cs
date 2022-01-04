using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Transform[] projectileSpawnPoints;

    [SerializeField] private float shootTimerTreshold = 0.2f;

    private float _shootTimer;
    private bool _canShoot;

    private void Update() 
    {
        if(Time.time > _shootTimer)
            _canShoot = true;
        HandlePlayerShooting();
    }

    void HandlePlayerShooting()
    {
        if(!_canShoot)
            return;

        //SHoot Blaster 1
        if(Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(projectiles[0], projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[0], projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        //Shoot Blaster 2
        if(Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(projectiles[1], projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[1], projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        //Shoot Laser
        if(Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(projectiles[2], projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[2], projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        //Shoot Rocket
        if(Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(projectiles[3], projectileSpawnPoints[2].position, Quaternion.identity);

            ResetShootingTimer();
        }

                //Shoot Misile
        if(Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(projectiles[4], projectileSpawnPoints[2].position, Quaternion.identity);

            ResetShootingTimer();
        }
    }

    void ResetShootingTimer()
    {
        _canShoot = false;
        _shootTimer = Time.time + shootTimerTreshold;
    }
}
