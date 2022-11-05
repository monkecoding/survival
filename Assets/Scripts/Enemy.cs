using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50, damage = 5, money = 100;
    public float speed = 1.5f, pushPower = 400;
    bool cd;
    private IEnumerator cooldown;
    public Transform[] wayPoints;
    Rigidbody2D rb;
    GameObject player, moneybar;
    Vector2 moveDirection, knockDirection;
    Vector2[] magnitudes;



    void Start()
    {
        FindClosetWayPoint();
        player = GameObject.FindGameObjectWithTag("Player");
        moneybar = GameObject.Find("Money Bar");
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(magnitudes.Length);
    }

    void Update()
    {
        // Determine direction and moving
        moveDirection = player.transform.position - this.transform.position;

        if (moveDirection.magnitude > 1)
        {
            transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Death condition
        if (health <= 0)
        {
            Destroy(gameObject);
            moneybar.GetComponent<MoneyBar>().balance += money;
            Events.SendEnemyKilled();
        }
    }


        // Taking damage
    public void CauseDamage(int damageAmount)
    {
        health -= damageAmount;
    }

        // Dealing damage to player
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.gameObject.GetComponent<Player>().isImmune && !isCooldown)
        {
            cooldown = Cooldown();
            StartCoroutine(cooldown);
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            knockDirection = this.transform.position - collision.transform.position;
            rb.AddForce(knockDirection * pushPower, ForceMode2D.Impulse);
        }


    }
        // Cooldown between attack
    private IEnumerator Cooldown()
    {
        cd = true;
        yield return new WaitForSeconds(0.3f);
        cd = false;
    }

    private bool isCooldown
    {
        get
        {
            return cd;
        }

        set
        {
            cd = value;
        }
    }

    void FindClosetWayPoint()
    {
        

        for (int i = 0; i < wayPoints.Length; i++)
        {
            magnitudes[i] = gameObject.transform.position - wayPoints[i].transform.position;
            Debug.Log("magnitude: " + magnitudes[i].magnitude);
        }
        
    }
}
