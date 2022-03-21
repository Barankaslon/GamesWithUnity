using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponManager[] playerWeapons;
    [SerializeField] private GameObject[] weapoonBullets;
    private int weaponIndex;
    private void Awake() 
    {
        weaponIndex = 0;
        playerWeapons[weaponIndex].gameObject.SetActive(true);
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

}
