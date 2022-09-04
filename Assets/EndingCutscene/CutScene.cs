using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite cut1;
    [SerializeField] private Sprite cut2;
    [SerializeField] private Sprite cut3;
    [SerializeField] private Sprite cut4;
    [SerializeField] private Sprite cut5;
    [SerializeField] private Sprite cut6;
    [SerializeField] private Sprite cut7;
    [SerializeField] private Sprite cut8;

    private int index = 0;
    private Dictionary<int, Sprite> scenes;

    void Start()
    {
        scenes = new Dictionary<int,Sprite>() {
            {0, cut1},
            {1, cut2},
            {2, cut3},
            {3, cut4},
            {4, cut5},
            {5, cut6},
            {6, cut7}
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            index++;
            if(scenes.ContainsKey(index))
            {
                spriteRenderer.sprite = scenes[index];
            }
            else
            {
                spriteRenderer.sprite = null;
            }
        }
    }
}
