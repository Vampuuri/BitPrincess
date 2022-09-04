using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip horrorClip;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite cut1;
    [SerializeField] private Sprite cut2;
    [SerializeField] private Sprite cut3;
    [SerializeField] private Sprite cut4;
    [SerializeField] private Sprite cut5;
    [SerializeField] private Sprite cut6;
    [SerializeField] private Sprite cut7;
    [SerializeField] private Sprite cut8;

    [SerializeField] Text ThankYouText;
    [SerializeField] Text CreditsText;

    private string thankYouString = "Thank you\nfor playing";
    private string creditsString = "Programming\nVampuuri\n\nConcept, level design\nStormwave\n\nEnvironment Graphics\nShaakku\n\nCharacter design, animations, graphics\nMizku";

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
            if (index == 3)
            {
                AudioSource.clip = horrorClip;
                AudioSource.Play();
            }
            if(scenes.ContainsKey(index))
            {
                spriteRenderer.sprite = scenes[index];
            }
            else if (index == scenes.Count)
            {
                ThankYouText.text = thankYouString;
                CreditsText.text = creditsString;
                spriteRenderer.sprite = null;
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
