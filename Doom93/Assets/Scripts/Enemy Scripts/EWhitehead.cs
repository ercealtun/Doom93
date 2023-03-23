using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EWhitehead : Enemy
{

    public EWhitehead()
    {
        health = 3;
        playerRange = 5f;
        moveSpeed = 1;
        fireRate = .5f;
    }
    
    private void Awake()
    {
        bullet = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Bullet .prefab");
        explosion = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Explosion.prefab");
        rigidbody2D = GetComponent<Rigidbody2D>();
        firePoint = transform.GetChild(0).GetChild(0);
    }
}
