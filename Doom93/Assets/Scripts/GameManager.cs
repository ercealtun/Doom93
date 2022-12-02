using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool tryToResume;
    private void Awake()
    {
        LockCursor();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!tryToResume) // Trying to unlock
            {
                UnlockCursor();
                tryToResume = true;
            }
            else // Trying to lock
            {
                LockCursor();
                tryToResume = false;
            }
        }
        

        
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
