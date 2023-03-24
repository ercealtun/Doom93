using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This scripts orders the enemies

public class EnemyCreator : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();

    [SerializeField] private EnemyFabric enemyFabric;
    
    // Start is called before the first frame update
    void Start()
    {
        enemies.Add(enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Whitehead));
        enemies.Add(enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Whitehead));
        enemies.Add(enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Daredevil));
        enemies.Add(enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Maddened));
        enemies.Add(enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Maddened));
        enemies.Add(enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Daredevil));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
