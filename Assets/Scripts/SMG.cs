using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Weapon
{

    void Start()
    {
        /*
        weaponName = "SMG";
        weaponDamage = 15;
        numberBullets = 1;
        spread = 1.0f;
        fullMagazine = 30;
        reloadTime = 2.0f;
        firerate = 0.1f;
        price = 500;
        */
        magazine = fullMagazine;
        gunPosition = this.gameObject.transform.GetChild(0);
        weaponBar = GameObject.Find("Weapon Bar");
        weaponBar.GetComponent<WeaponBar>().weaponName = weaponName;
    }

    void Update()
    {
        // Gun controlls
        if (Input.GetButton("Fire1"))
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
