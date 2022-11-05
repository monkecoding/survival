using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 100;
    public bool immune;
    private IEnumerator beImmune;

    public bool isImmune
    {
        get 
        {
            return immune;
        }
        

        set 
        {
            immune = value;
        }

    }

    public void TakeDamage(int damageAmount)
    {
        if (!isImmune) 
        {
        beImmune = Imune();
        health -= damageAmount;
        Debug.Log("Player health is " + health);
        StartCoroutine(beImmune);
        }
    }
    private IEnumerator Imune()
    {
        isImmune = true;
        yield return new WaitForSeconds(0.2f);
        isImmune = false;
    }
}
