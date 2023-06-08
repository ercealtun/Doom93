using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDecorator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            if (PlayerController.instance.TryGetComponent(out PlayerDebugger playerDebugger))
            {
                Destroy(PlayerController.instance.GetComponent<PlayerDebugger>());
            }
            else
            {
                PlayerController.instance.AddComponent<PlayerDebugger>();
            }
        }
    }
}
