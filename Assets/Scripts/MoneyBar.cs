using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBar : MonoBehaviour
{
    public int balance = 0;
    TMP_Text scorebar;

    void Start()
    {
        scorebar = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        scorebar.text = "$ " + balance;
    }
}
