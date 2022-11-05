using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public GameObject shopMenu;

    public void ShowStore()
    {
            GameObject menu = Instantiate(shopMenu);
            menu.transform.SetParent(GameObject.Find("Canvas").transform, false);
            gameObject.GetComponent<Button>().interactable = false; 
    }
}
