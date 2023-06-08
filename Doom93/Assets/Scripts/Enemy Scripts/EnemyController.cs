using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D rigidbody2D;
    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint; 
    

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position; // equals -> Player's position - enemy's position

            rigidbody2D.velocity = playerDirection.normalized * moveSpeed;

            if (shouldShoot)
            {
                shotCounter -= Time.deltaTime; // countdown
                if (shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }

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
            
            
            AudioManager.Instance.PlayEnemyDead();
        }
        else
        {
            AudioManager.Instance.PlayEnemyShot();
        }
        
    }
}
