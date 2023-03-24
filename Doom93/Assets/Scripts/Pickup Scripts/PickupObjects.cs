using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    private Pickup pickup;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            PlayerController.instance.AddHealth(pickup.getHealthValue());
            
            PlayerController.instance.currentAmmo += pickup.getAmmoValue();
            PlayerController.instance.UpdateAmmoUI();
            

            if (pickup.getHealthValue() == 0) // If this isn't a health pickup
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
