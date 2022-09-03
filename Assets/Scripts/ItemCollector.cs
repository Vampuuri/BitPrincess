using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int passwords = 0;

    [SerializeField] private Text passwordsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PasswordCollectable"))
        {
            Destroy(collision.gameObject);
            passwords++;
            Debug.Log("Passwords: " + passwords);
            //passwordsText.text = "Passwords: " + passwords;
        }
    }
}
