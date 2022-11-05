using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Variables
    public GameObject bullet;
    public int weaponDamage, fullMagazine, magazine, numberBullets, price;
    public float reloadTime, firerate, spread, spreadX, spreadY;
    public bool reload, cooldown;
    public string weaponName;
    public GameObject weaponBar;
    public Transform gunPosition;
    Transform firePosition;

    void Start()
    {
        magazine = fullMagazine;

    }


    void Update()
    {


    }

    public void Shoot()
    {
        // Shooting system
        if (!reload && !cooldown)
        {
        --magazine;
            for (int i = 0; i < numberBullets; i++)
            {
                firePosition = gunPosition;
                spreadX = Random.Range(-1f, 1f);
                spreadY = Random.Range(-0.5f, 0.5f);
                spread = Random.Range(-spread, spread);
                firePosition.localPosition = new Vector2(spreadX, spreadY);
                GameObject clone = Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation);
                clone.gameObject.GetComponent<Bullet>().bulletDamage = weaponDamage;
                Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
                clonerb.velocity = transform.TransformDirection(spread * 1.5f, 20, 0);
            }
            StartCoroutine(Cooldown());
        }
    }

    public IEnumerator Reloading()
    {
        // Reload system
        reload = true;
        magazine = fullMagazine;
        yield return new WaitForSeconds(reloadTime);
        reload = false;
    }
    public IEnumerator Cooldown() 
    {
    cooldown = true;
    yield return new WaitForSeconds(firerate);
    cooldown = false;
    }
}