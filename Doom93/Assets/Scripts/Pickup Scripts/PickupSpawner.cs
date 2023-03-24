using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private GameObject healthPrefab;

    
    public GameObject[] spawnPoints;
    public int spawnerIndex = 0;


    private void Start()
    {
        SpawnPickups(PickupSpawner.PickupTypes.Health);
        SpawnPickups(PickupSpawner.PickupTypes.Ammo);
        SpawnPickups(PickupSpawner.PickupTypes.Health);
        SpawnPickups(PickupSpawner.PickupTypes.Ammo);
        SpawnPickups(PickupSpawner.PickupTypes.Health);
        SpawnPickups(PickupSpawner.PickupTypes.Ammo);
    }

    public enum PickupTypes
    {
        Health,
        Ammo
    }


    public void SpawnPickups(PickupSpawner.PickupTypes type)
    {
        if (type == PickupTypes.Ammo)
        {
            GameObject ammoPickupObject = Instantiate(ammoPrefab,
                spawnPoints[spawnerIndex++].transform.position, 
                Quaternion.identity);
            PickupBreed ammoBreed = new PickupBreed(0, 15);
            Pickup ammoPickup = ammoBreed.NewPickup();
            ammoPickupObject.GetComponent<PickupObjects>().SetPickup(ammoPickup);
        }
        else if(type == PickupTypes.Health)
        {
            GameObject healthPickupObject = Instantiate(healthPrefab,
                spawnPoints[spawnerIndex++].transform.position, 
                Quaternion.identity);
            PickupBreed healthBreed = new PickupBreed(15, 0);
            Pickup healthPickup = healthBreed.NewPickup();
            healthPickupObject.GetComponent<PickupObjects>().SetPickup(healthPickup);
        }

    }
}
