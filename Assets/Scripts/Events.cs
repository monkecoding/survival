using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{

    public static UnityEvent OnEnemyKilled = new UnityEvent();

    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }
}
