using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    MainManager manager;
    [SerializeField] private ParticleSystem sparkleEffect;
    [SerializeField] private AudioSource collectionSoundEffect;

    void Start()
    {
        GameObject managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<MainManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PasswordCollectable"))
        {
            collectionSoundEffect.Play();
            sparkleEffect.Play();
            Destroy(collision.gameObject);
            manager.SetCarriesPassword(true);
        }
    }
}
