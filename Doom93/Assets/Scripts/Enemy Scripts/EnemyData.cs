using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    private float fireRate = 0.5f;
    private float moveSpeed = 1.2f;
    
    public float FireRate => fireRate;
    public float MoveSpeed => moveSpeed;
}
