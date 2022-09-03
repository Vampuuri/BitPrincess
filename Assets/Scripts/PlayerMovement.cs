using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D player;
	private BoxCollider2D ground;
	
	[SerializeField] private LayerMask jumpableGround;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
		ground = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
		float dirX = Input.GetAxis("Horizontal");
		player.velocity = new Vector2(5f * dirX, player.velocity.y);
		
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
			player.velocity = new Vector2(player.velocity.x, 12f);
		}
    }
	
	private bool IsGrounded()
	{
		return Physics2D.BoxCast(ground.bounds.center, ground.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
	}
}
