using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    void Start()
    {
        /*
        weaponName = "Shotgun";
;       weaponDamage = 5;
        numberBullets = 7;
        spread = 1.5f;
        fullMagazine = 6;
        reloadTime = 2.5f;
        firerate = 0.6f;
        price = 300;
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
