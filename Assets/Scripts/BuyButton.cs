using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public int weaponId, weaponPrice, balance;
    public string weaponName;
    GameObject playerUnlocker, moneyBar;
    TMP_Text description;


    void Start()
    {
        // Initiating button
        moneyBar = GameObject.Find("Money Bar");
        playerUnlocker = GameObject.Find("Player");
       // Debug.Log("Name " + weaponName + " Price - " + weaponPrice + " Id: " + weaponId);
        description = gameObject.GetComponentInChildren<TMP_Text>();
        description.text = weaponName.ToString() + " " + weaponPrice.ToString() + "$";

    }

    public void UnlockWeapon()
    {
        // Send info about unlock
        if (moneyBar.GetComponent<MoneyBar>().balance > weaponPrice)
        {
            gameObject.GetComponent<Button>().interactable = false;
            moneyBar.GetComponent<MoneyBar>().balance -= weaponPrice;
            playerUnlocker.GetComponent<PlayerController>().weaponsUnlocks[weaponId] = true;
        }
    }
}