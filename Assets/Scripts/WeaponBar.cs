using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponBar : MonoBehaviour
{
    public string ammo;
    public string weaponName;
    TMP_Text weaponInfo;
    
    
    void Start()
    {
        weaponInfo = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        weaponInfo.text = "Ammo: " + ammo + weaponName;
    }
}

