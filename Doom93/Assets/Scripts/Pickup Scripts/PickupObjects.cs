using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    private Pickup pickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            PlayerController.instance.AddHealth(pickup.GetHealthValue());
            
            PlayerController.instance.currentAmmo += pickup.GetAmmoValue();
            PlayerController.instance.UpdateAmmoUI();
            

            if (pickup.GetHealthValue() == 0) // If this isn't a health pickup
            {
                AudioManager.Instance.PlayAmmoPickup();
                
            }
            else
            {
                AudioManager.Instance.PlayHealthPickup();
            }
            
            Destroy(gameObject);

        }
        
        
    }

    public void SetPickup(Pickup pickup)
    {
        this.pickup = pickup;
    }
}
