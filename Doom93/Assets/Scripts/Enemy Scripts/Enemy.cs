using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
    // VARIABLES
    public static int deadEnemyCount = 0;

    public int health;
    public GameObject explosion;

    public float playerRange;

    public Rigidbody2D rigidbody2D;
    public float moveSpeed;
    
    public float fireRate;
    public float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    // METHODS
    
    public abstract void DetectPlayer();
    public abstract void TakeDamage();
    public abstract Enemy Clone();

}
