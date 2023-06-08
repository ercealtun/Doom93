using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class

/*
 * Abstract class and implements prototype and strategy patterns
 */

public abstract class Enemy : MonoBehaviour
{
    private IStrategyAttack strategyAttack = new IAttackA();
    
    // VARIABLES
    public static int deadEnemyCount = 0;

    public int health;
    public GameObject explosion;

    public float playerRange;

    public Rigidbody2D rigidbody2D;

    public float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    // METHODS
    public abstract void DetectPlayer();
    public abstract void TakeDamage();

    public void DebugWhenAttacked()
    {
        strategyAttack.GetAttackType();
    }

    public void SwitchAttacks(IStrategyAttack strategyAttack)
    {
        this.strategyAttack = strategyAttack;
    }
    public Enemy Clone()
    {
        return (Enemy)MemberwiseClone();
    }

}
