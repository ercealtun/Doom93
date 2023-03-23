using System.Collections;
using System.Collections.Generic;
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
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Enemy FabricateEnemy(EnemyType enemyType)
    {
        if (enemyType == EnemyType.Whitehead)
        {
            GameObject whitehead = Instantiate(whiteheadPrefab,
                spawnPoints[spawnerIndex++].transform.position, 
                Quaternion.identity);
            whitehead.AddComponent<EWhitehead>();
            return new EWhitehead();
        }else if (enemyType == EnemyType.Daredevil)
        {
            GameObject daredevil = Instantiate(daredevilPrefab,
                spawnPoints[spawnerIndex++].transform.position,
                Quaternion.identity);
            daredevil.AddComponent<EDaredevil>();
            return new EDaredevil();
        }else if (enemyType == EnemyType.Maddened)
        {
            GameObject maddened = Instantiate(maddenedPrefab,
                spawnPoints[spawnerIndex].transform.position,
                Quaternion.identity);
            maddened.AddComponent<EMaddened>();
            return new EMaddened();
        }
        else
        {
            return null;
        }
    }
}
