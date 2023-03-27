using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
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

        if (Enemy.deadEnemyCount == 6)
        {
            gameIsDoneScreen.SetActive(true);
            Enemy.deadEnemyCount = 0;
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
