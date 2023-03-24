// This script has been coded in accordance with the SINGLETON pattern

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    
    public AudioSource ammo, enemyDeath, enemyShot, gunShot, health, playerHurt, backgroundMusic;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    #region AUDIO Methods

    public void PlayAmmoPickup()
    {
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
        enemyShot.Stop(); 
        enemyShot.Play();
    }
    
    public void PlayGunShot()
    {
        gunShot.Stop(); 
        gunShot.Play();
    }
    
    public void PlayHealthPickup()
    {
        health.Stop(); 
        health.Play();
    }
    
    public void PlayPlayerHurt()
    {
        playerHurt.Stop(); 
        playerHurt.Play();
    }
    
    
    public void PlayBackgroundMusic()
    {
        backgroundMusic.Stop(); 
        backgroundMusic.Play();
    }

    #endregion
    

}
