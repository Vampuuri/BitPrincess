using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string Level;

    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.Find("GameManager");
        MainManager managerScript = manager.GetComponent<MainManager>();
        Debug.Log(managerScript.GetLevels()[0]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Siirrytään leveliin: " + Level);
            SceneManager.LoadScene(Level + "Scene");
        }
    }
}
