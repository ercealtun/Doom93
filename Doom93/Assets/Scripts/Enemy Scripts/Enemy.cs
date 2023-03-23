using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public static int deadEnemyCount = 0;

    public int health;
    public GameObject explosion;

    public float playerRange;

    public Rigidbody2D rigidbody2D;
    public float moveSpeed;

    //public bool shouldShoot;
    public float fireRate;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {

            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position; // equals -> Player's position - enemy's position

            rigidbody2D.velocity = playerDirection.normalized * moveSpeed;

            /*
            if (shouldShoot)
            {
                shotCounter -= Time.deltaTime; // countdown
                if (shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }

            }
            */
            
            
            shotCounter -= Time.deltaTime; // countdown
            if (shotCounter <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = fireRate;
            }
            
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        
        
        
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            deadEnemyCount++;
            print("Enemy count is: " + deadEnemyCount);
            
            AudioManager.Instance.playEnemyDead();
        }
        else
        {
            AudioManager.Instance.playEnemyShot();
        }
    }
    

    
}
