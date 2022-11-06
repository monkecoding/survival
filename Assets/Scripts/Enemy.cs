using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Enemy : MonoBehaviour
{
    public int health = 50, damage = 5, money = 100;
    public float speed = 1.5f, pushPower = 400;
    bool cd, inHouse;
    private IEnumerator cooldown;
    GameObject[] wayPoints;
    Rigidbody2D rb;
    GameObject player, moneybar, closeWayPoint;
    Vector2 playerDirection, wayPointDirection, knockDirection;
    Vector2[] magnitudesWayPoints;
    float closeWayPointMagnitude;



    void Start()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("Way Point");
        player = GameObject.FindGameObjectWithTag("Player");
        moneybar = GameObject.Find("Money Bar");
        magnitudesWayPoints = new Vector2[wayPoints.Length];
        rb = GetComponent<Rigidbody2D>();
        FindClosetWayPoint();
    }

    void Update()
    {
        // Determine direction and moving
        playerDirection = player.transform.position - this.transform.position;
        wayPointDirection = closeWayPoint.transform.position - this.transform.position;
        GoToClose();




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

    // Find way in house
    void FindClosetWayPoint()
    {

        // Initiating way points into magnitudes
        for (int i = 0; i < wayPoints.Length; i++)
        {
            magnitudesWayPoints[i] = gameObject.transform.position - wayPoints[i].transform.position;
        }

        closeWayPointMagnitude = magnitudesWayPoints.Select(x => x.magnitude).Min();

        for (int i = 0; i < magnitudesWayPoints.Length; i++)
        {
            if(magnitudesWayPoints[i].magnitude == closeWayPointMagnitude)
            {
                closeWayPoint = wayPoints[i];
                break;
            }
        }
    }

    // Way controller
    void GoToClose()
    {
        if (wayPointDirection.magnitude > 0.1 && !inHouse)
        {
            transform.Translate(wayPointDirection.normalized * speed * Time.deltaTime);  
        }
        else
        {
            inHouse = true;
            GoToPlayer();
        }
    }

    void GoToPlayer()
    {
        if (playerDirection.magnitude > 1)
        {
            transform.Translate(playerDirection.normalized * speed * Time.deltaTime);
        }
    }
}
