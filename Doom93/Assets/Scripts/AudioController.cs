using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource ammo, enemyDeath, enemyShot, gunShot, health, playerHurt;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAmmoPickup()
    {
        // We stop ammo's audio first, because when we pick ammo in consecutive order we would want to hear ammo sound again and again
        ammo.Stop(); 
        ammo.Play();
    }
    
    public void PlayEnemyDead()
    {
        enemyDeath.Stop(); 
        enemyDeath.Play();
    }
    
    public void PlayEnemyShot()
    {
        // We stop ammo's audio first, because when we pick ammo in consecutive order we would want to hear ammo sound again and again
        enemyShot.Stop(); 
        enemyShot.Play();
    }
    
    public void PlayGunShot()
    {
        // We stop ammo's audio first, because when we pick ammo in consecutive order we would want to hear ammo sound again and again
        gunShot.Stop(); 
        gunShot.Play();
    }
    
    public void PlayHealthPickup()
    {
        // We stop ammo's audio first, because when we pick ammo in consecutive order we would want to hear ammo sound again and again
        health.Stop(); 
        health.Play();
    }
    
    public void PlayPlayerHurt()
    {
        // We stop ammo's audio first, because when we pick ammo in consecutive order we would want to hear ammo sound again and again
        playerHurt.Stop(); 
        playerHurt.Play();
    }
}
