using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int passwords = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PasswordCollectable"))
        {
            Destroy(collision.gameObject);
            passwords++;
            Debug.Log(passwords);
        }
    }
}
