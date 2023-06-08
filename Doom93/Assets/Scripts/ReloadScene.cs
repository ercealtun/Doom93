using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void ResetScene()
    {
        AudioManager.Instance.PlayBackgroundMusic();
        Debug.Log("Reloaded scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EnemyFabric.instance.spawnerIndex = 0;

    }
}
