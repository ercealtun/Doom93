using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TYPE OBJECT pattern implemented
 */

public class PickupBreed
{
    private int healthValue;
    private int ammoValue;

    public PickupBreed(int healthValue, int ammoValue)
    {
        this.healthValue = healthValue;
        this.ammoValue = ammoValue;
        
    }

    public Pickup NewPickup()
    {
        return new Pickup(this);
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
