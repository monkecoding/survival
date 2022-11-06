using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float health, maxHealth = 100;
    public bool immune;
    public Image healthBar;
    private IEnumerator beImmune;

    private void Awake()
    {
        health = maxHealth;
    }

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
        healthBar.fillAmount = health / maxHealth;
        CheckHealth();
        StartCoroutine(beImmune);
        }

    }
    private IEnumerator Imune()
    {
        isImmune = true;
        yield return new WaitForSeconds(0.2f);
        isImmune = false;
    }
    
    private void CheckHealth()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
