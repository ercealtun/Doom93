using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Child class : Flyweight and strategy pattern implemented

public class EDaredevil : Enemy
{
    public EnemyData enemyData = null;
    
    public EDaredevil()
    {
        health = 10;
        playerRange = 5.2f;

    }
    
    #region Unity methods

    private void Start()
    {
        shotCounter = enemyData.FireRate;
    }
    
    void Update()
    {
        DetectPlayer();
    }
    #endregion

    #region Overriden methods

    public override void DetectPlayer()
    {
        // If found player shoot
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            DebugWhenAttacked();
            
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position; // equals -> Player's position - enemy's position

            rigidbody2D.velocity = playerDirection.normalized * enemyData.MoveSpeed * 0.7f ;

            shotCounter -= Time.deltaTime * 0.5f; // Countdown
            if (shotCounter <= 0)
            {
        
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = enemyData.FireRate;
            }
            
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    public override void TakeDamage()
    {
        health-=2;
        if (health <= 0)
        {
             
            
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            deadEnemyCount++;

            AudioManager.Instance.PlayEnemyDead();
        }
        else
        {
            AudioManager.Instance.PlayEnemyShot();
        }
    }

    #endregion
    

}
