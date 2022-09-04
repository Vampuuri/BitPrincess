using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string Level;
    MainManager manager;

    public SpriteRenderer spriteRenderer;
    public Sprite activeSprite;
    public Sprite inActiveSprite;

    void Awake()
    {
        GameObject managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<MainManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!manager.GetLevels().Contains(Level) && !Level.Equals("MainGame")) {
            Destroy(gameObject);
        }
        else if (manager.lockLevels)
        {
            spriteRenderer.sprite = inActiveSprite;
        }
    }

    public void activate()
    {
        if (activeSprite)
        {
            spriteRenderer.sprite = activeSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (manager.IsCarryingPassword())
            {
                manager.lockLevels = true;
                manager.RemoveCurrentLevel();
            }
            if (Level.Equals("MainGame") || spriteRenderer.sprite.Equals(activeSprite))
            {
                SceneManager.LoadScene(Level + "Scene");
                manager.SetCurrentLevel(Level);
            }
        }
    }
}
