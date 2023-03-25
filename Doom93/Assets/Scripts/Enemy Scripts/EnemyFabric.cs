using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
/*
 * FACTORY and PROTOTYPE pattern implemented
 */
public class EnemyFabric : MonoBehaviour
{
    public static EnemyFabric instance;

    [SerializeField] private GameObject whiteheadPrefab;
    [SerializeField] private GameObject daredevilPrefab;
    [SerializeField] private GameObject maddenedPrefab;
    
    public GameObject[] spawnPoints;
    public int spawnerIndex = 0;

    private EWhitehead whiteheadPrototype = new EWhitehead();
    private EDaredevil daredevilPrototype = new EDaredevil();
    private EMaddened maddenedPrototype = new EMaddened();

    public enum EnemyType
    {
        Whitehead,
        Daredevil,
        Maddened 
    }

    public Enemy FabricateEnemy(EnemyType enemyType)
    {
        if (enemyType == EnemyType.Whitehead)
        {
            GameObject whitehead = Instantiate(whiteheadPrefab,
                spawnPoints[spawnerIndex++].transform.position, 
                Quaternion.identity);
            Enemy newEnemy = whiteheadPrototype.Clone();
            newEnemy = whitehead.AddComponent<EWhitehead>();
            return newEnemy;
        }else if (enemyType == EnemyType.Daredevil)
        {
            GameObject daredevil = Instantiate(daredevilPrefab,
                spawnPoints[spawnerIndex++].transform.position,
                Quaternion.identity);
            Enemy newEnemy = daredevilPrototype.Clone();
            newEnemy = daredevil.AddComponent<EDaredevil>();
            return newEnemy;
        }else if (enemyType == EnemyType.Maddened)
        {
            GameObject maddened = Instantiate(maddenedPrefab,
                spawnPoints[spawnerIndex++].transform.position,
                Quaternion.identity);
            Enemy newEnemy = maddenedPrototype.Clone();
            newEnemy = maddened.AddComponent<EMaddened>();
            return newEnemy;
        }

        return null;

    }
    
}
