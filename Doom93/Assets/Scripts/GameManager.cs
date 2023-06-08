using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject gameIsDoneScreen;

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
        
        print("enemy: " + Enemy.deadEnemyCount);

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

        switch (Enemy.deadEnemyCount)
        {
            case 6:
                gameIsDoneScreen.SetActive(true);
                Enemy.deadEnemyCount = 0;
                break;
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
