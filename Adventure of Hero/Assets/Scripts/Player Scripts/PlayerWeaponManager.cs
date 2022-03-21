using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponManager[] playerWeapons;
    [SerializeField] private GameObject[] weaponBullets;

    private Vector2 targetPos;
    private Vector2 direction;
    private Vector2 bulletSpawnPosition;
    private Quaternion bulletRotation;
    private Camera mainCam;

    private int weaponIndex;
    private void Awake() 
    {
        weaponIndex = 0;
        playerWeapons[weaponIndex].gameObject.SetActive(true);
        mainCam = Camera.main;
    }

    public void ActivateGun(int gunIndex)
    {
        playerWeapons[weaponIndex].ActivateGun(gunIndex);
    }

    private void Update() 
    {
        ChangeWeapon();
    }

    void ChangeWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            playerWeapons[weaponIndex].gameObject.SetActive(false);
            weaponIndex++;

            if(weaponIndex == playerWeapons.Length)
                weaponIndex = 0;

            playerWeapons[weaponIndex].gameObject.SetActive(true);
        }
    }

    public void Shoot(Vector3 spawnPos)
    {
        targetPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        bulletSpawnPosition = new Vector2(spawnPos.x, spawnPos.y);
        direction = (targetPos - bulletSpawnPosition).normalized;
        bulletRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        GameObject newBullet = Instantiate(weaponBullets[weaponIndex], spawnPos, bulletRotation);
        newBullet.GetComponent<Bullet>().MoveInDirection(direction);
    }

}
