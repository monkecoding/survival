using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CloseButton : MonoBehaviour
{
    GameObject openButton;

    void Start()
    {
        openButton = GameObject.Find("Store");
    }

    void Update()
    {
        
    }

    public void CloseShopMenu()
    {
        openButton.GetComponent<Button>().interactable = true;
        Destroy(transform.parent.gameObject);
    }
}
