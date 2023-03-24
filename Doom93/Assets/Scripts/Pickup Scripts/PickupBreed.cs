using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int getHealthValue()
    {
        return healthValue;
        
    }

    public int getAmmoValue()
    {
        return ammoValue;
    }



}
