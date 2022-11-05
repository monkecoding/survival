using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KillCounter : MonoBehaviour
{
    public int killed;

    void Start()
    {
        Events.OnEnemyKilled.AddListener(EnemyKilled);
    }

    void EnemyKilled()
    {
        killed++;
        GetComponent<TMP_Text>().text = "Killed: " + killed;
    }
}
