using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordHandler : MonoBehaviour
{
    MainManager manager;

    void Start()
    {
        GameObject managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<MainManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PasswordReceptor"))
        {
            manager.PasswordDelivered();
        }
    }
}
