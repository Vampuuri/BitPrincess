using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string Level;
    MainManager manager;

    void Awake()
    {
        GameObject managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<MainManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!manager.GetLevels().Contains(Level) && !Level.Equals("MainGame")) {
            Debug.Log("I don't exist " + Level);
            Destroy(gameObject);
        }
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
