using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPassage : MonoBehaviour
{
    [SerializeField] GameObject infoMessage;
    [SerializeField] Text infoMessageText;

    private WaitForSeconds WaitForFiveSeconds = new WaitForSeconds(5f);

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        infoMessage.SetActive(true);
        if (Enemy.deadEnemyCount == 5)
        {
            infoMessageText.text = "Welcome to the Great Enemy";
            Debug.Log("Welcome to the Great Enemy");
            GetComponent<BoxCollider2D>().enabled = false;

        }
        else if(Enemy.deadEnemyCount < 5)
        {
            infoMessageText.text = "Can't open the door.\n Try killing all the enemies.";
            Debug.Log("Can't open the door. Try killing all the enemies");
        }

        StopCoroutine(WaitForFiveSec());
        StartCoroutine(WaitForFiveSec());
    }

    IEnumerator WaitForFiveSec()
    {
        yield return WaitForFiveSeconds;
        infoMessage.SetActive(false);
    }

}
