using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EDaredevil : Enemy
{
    public EDaredevil()
    {
        health = 5;
        playerRange = 5.2f;
        moveSpeed = 1.2f;
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
