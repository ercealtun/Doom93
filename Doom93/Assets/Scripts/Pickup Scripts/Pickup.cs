using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup
{
    private int healthValue { get; }
    private int ammoValue { get; }
    private PickupBreed _pickupBreed;

    public Pickup(PickupBreed pickupBreed)
    {
        _pickupBreed = pickupBreed;
        healthValue = _pickupBreed.getHealthValue();
        ammoValue = _pickupBreed.getAmmoValue();
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
