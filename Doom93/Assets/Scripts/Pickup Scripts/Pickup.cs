using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TYPE OBJECT pattern implemented
 */


public class Pickup
{
    private int healthValue;
    private int ammoValue;
    private PickupBreed pickupBreed;

    public Pickup(PickupBreed pickupBreed)
    {
        this.pickupBreed = pickupBreed;
        healthValue = pickupBreed.GetHealthValue();
        ammoValue = pickupBreed.GetAmmoValue();
    }


    public int GetHealthValue()
    {
        return healthValue;
        
    }

    public int GetAmmoValue()
    {
        return ammoValue;
    }
    

    
}
