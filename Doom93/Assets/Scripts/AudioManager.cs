// This script has been coded in accordance with the SINGLETON pattern

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    
    public AudioSource ammo, enemyDeath, enemyShot, gunShot, health, playerHurt, backgroundMusic;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }

    }
    
    public static AudioManager Instance
    {
        get
        {
            /* If instance is null, the FindObjectOfType function
             finds this existing script object in the scene and assigns 
             it to the instance variable.
            */ 
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                
                // If it's still null, then create a new game object with AudioManager(Singleton) component
                if (instance == null) 
                {
                    instance = new GameObject("AudioManager").AddComponent<AudioManager>();
                    
                    /*
                    GameObject gameObject = new GameObject();
                    gameObject.name = typeof(AudioManager).Name;
                    instance = gameObject.AddComponent<AudioManager>();
                    DontDestroyOnLoad(gameObject);
                    */
                }
            }
            return instance;
        }
    }

    #region AUDIO Methods

    public void playAmmoPickup()
    {
        ammo.Stop(); 
        ammo.Play();
    }
    
    public void playEnemyDead()
    {
        enemyDeath.Stop(); 
        enemyDeath.Play();
    }
    
    public void playEnemyShot()
    {
        enemyShot.Stop(); 
        enemyShot.Play();
    }
    
    public void playGunShot()
    {
        gunShot.Stop(); 
        gunShot.Play();
    }
    
    public void playHealthPickup()
    {
        health.Stop(); 
        health.Play();
    }
    
    public void playPlayerHurt()
    {
        playerHurt.Stop(); 
        playerHurt.Play();
    }
    
    
    public void playBackgroundMusic()
    {
        backgroundMusic.Stop(); 
        backgroundMusic.Play();
    }

    #endregion
    

}
