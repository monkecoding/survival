using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public GameObject player, buyButton;
    public GameObject[] buyButtons;
    GameObject playerUnlocker;
    GameObject[] weapons;
    


    void Start()
    {
        weapons = GameObject.Find("Player").GetComponent<PlayerController>().weapons;
        playerUnlocker = GameObject.Find("Player");

        // Initialization buy button
        buyButtons = new GameObject[weapons.Length];

        for (int i = 0; i < buyButtons.Length; i++)    
        {
            buyButtons[i] = buyButton;
            GameObject weaponButton = Instantiate(buyButtons[i], gameObject.transform);
            weaponButton.transform.Translate(0, -1 * i, 0);
            weaponButton.GetComponent<BuyButton>().weaponId = i;
            weaponButton.GetComponent<BuyButton>().weaponName = weapons[i].name;
            weaponButton.GetComponent<BuyButton>().weaponPrice = weapons[i].GetComponent<Weapon>().price;

            // Checking unlocked weapon
            if (playerUnlocker.GetComponent<PlayerController>().weaponsUnlocks[i] == true)
            {
                weaponButton.GetComponent<Button>().interactable = false;
            }
        }
    }
}
