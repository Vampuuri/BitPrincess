using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainDesrtoyable : MonoBehaviour
{
    [SerializeField] private string level;
    MainManager manager;

    void Start()
    {
        GameObject managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<MainManager>();
        CheckDestroy(manager.destroyChains);
    }

    public void CheckDestroy(List<string> levels)
    {
        if (levels.Contains(level))
        {
            Destroy(gameObject);
        }
    }
}
