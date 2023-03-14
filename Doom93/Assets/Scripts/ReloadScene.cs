using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScene()
    {
        AudioManager.Instance.playBackgroundMusic();
        Debug.Log("Reloaded scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
