using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EDaredevil : Enemy
{
    //private GameObject daredevilPrefab;
    public EDaredevil()
    {
        health = 10;
        playerRange = 5.2f;
        moveSpeed = 1.2f;
        fireRate = .5f;
        shotCounter = fireRate;

    }
    
    #region Unity methods
    private void Awake()
    { 
        //daredevilPrefab = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Enemies/EnemyDaredevil.prefab");
        bullet = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Bullet.prefab");
        explosion = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Explosion.prefab");
        rigidbody2D = GetComponent<Rigidbody2D>();
        firePoint = transform.GetChild(0).GetChild(0);
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
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position; // equals -> Player's position - enemy's position

            rigidbody2D.velocity = playerDirection.normalized * moveSpeed * 0.7f ;

            shotCounter -= Time.deltaTime * 0.5f; // Countdown
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
