using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D player;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		float dirX = Input.GetAxis("Horizontal");
		player.velocity = new Vector2(5f * dirX, player.velocity.y);
		
        if (Input.GetButtonDown("Jump")) {
			player.velocity = new Vector2(player.velocity.x, 10f);
		}
    }
}
