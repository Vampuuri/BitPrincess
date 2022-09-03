using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private List<string> levels = new List<string>
        {"Level1", "Level2", "Level3", "Level4"};

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log(levels[0]);
    }

    public List<string> GetLevels()
    {
        return levels;
    }
}
