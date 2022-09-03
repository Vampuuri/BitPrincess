using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D player;
    MainManager manager;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        GameObject managerObject = GameObject.Find("GameManager");
        manager = managerObject.GetComponent<MainManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathTrap"))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("dead");
        manager.SetCarriesPassword(false);
        player.bodyType = RigidbodyType2D.Static;
        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("respawn");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
