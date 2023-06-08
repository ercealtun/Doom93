using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class EnemyFabric : MonoBehaviour
{
    public static EnemyFabric instance;

    [SerializeField] private GameObject whiteheadPrefab;
    [SerializeField] private GameObject daredevilPrefab;
    [SerializeField] private GameObject maddenedPrefab;
    
    public GameObject[] spawnPoints;
    public int spawnerIndex = 0;

    public enum EnemyType
    {
        Whitehead,
        Daredevil,
        Maddened 
    }

    private void Awake()
    {
        instance = this;
    }

    public void FabricateEnemy(EnemyType enemyType)
    {
        if (enemyType == EnemyType.Whitehead)
        {
            Instantiate(whiteheadPrefab,
                spawnPoints[spawnerIndex++].transform.position, 
                Quaternion.identity);
            //Enemy newEnemy = whiteheadPrototype.Clone();
            //newEnemy = whitehead.AddComponent<EWhitehead>();
            //return newEnemy;
        }else if (enemyType == EnemyType.Daredevil)
        {
            Instantiate(daredevilPrefab,
                spawnPoints[spawnerIndex++].transform.position,
                Quaternion.identity);
            /*
            Enemy newEnemy = daredevilPrototype.Clone();
            newEnemy = daredevil.AddComponent<EDaredevil>();
            return newEnemy;
            */
        }else if (enemyType == EnemyType.Maddened)
        {
            Instantiate(maddenedPrefab,
                spawnPoints[spawnerIndex++].transform.position,
                Quaternion.identity);
            /*
            Enemy newEnemy = maddenedPrototype.Clone();
            newEnemy = maddened.AddComponent<EMaddened>();
            return newEnemy;
            */
        }
    }

}
