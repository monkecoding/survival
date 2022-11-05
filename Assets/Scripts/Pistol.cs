using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{

    void Start()
    {
        /*
        weaponName = "Pistol";
        weaponDamage = 15;
        numberBullets = 1;
        spread = 0.8f;
        fullMagazine = 12;
        reloadTime = 1.5f;
        firerate = 0.2f;
        price = 0;
        */
        magazine = fullMagazine;
        gunPosition = this.gameObject.transform.GetChild(0);
        weaponBar = GameObject.Find("Weapon Bar");
        weaponBar.GetComponent<WeaponBar>().weaponName = weaponName;
    }

    void Update()
    {
        // Gun controlls
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        // Reload condition
        if (magazine == 0 || Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reloading());
        }
        // Reload info UI
        if (reload)
        {
            weaponBar.GetComponent<WeaponBar>().ammo = "Reloading ";
        }
        else
        {
            weaponBar.GetComponent<WeaponBar>().ammo = magazine.ToString() + " ";
        }
    }
}
