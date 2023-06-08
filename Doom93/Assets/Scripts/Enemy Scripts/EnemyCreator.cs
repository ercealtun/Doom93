using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Orders the enemies (enemy shop)
 */

public class EnemyCreator : MonoBehaviour
{

    [SerializeField] private EnemyFabric enemyFabric;

    // Start is called before the first frame update
    void Start()
    {
        enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Whitehead);
        enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Whitehead);
        enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Maddened);
        enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Daredevil);
        enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Daredevil);
        enemyFabric.FabricateEnemy(EnemyFabric.EnemyType.Daredevil);
    }
}
