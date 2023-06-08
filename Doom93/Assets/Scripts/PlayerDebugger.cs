using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebugger : MonoBehaviour
{
    public static PlayerDebugger instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player position => " + PlayerController.instance.transform.position); 
    }
}
