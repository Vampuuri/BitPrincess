using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyButtonListener : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("MainGameScene");
            }
        }
    }
}
