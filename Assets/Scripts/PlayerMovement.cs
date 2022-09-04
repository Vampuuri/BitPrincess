using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D player;
	private SpriteRenderer sprite;
	private BoxCollider2D ground;
	private Animator animator;

	private float dirX = 0;
	[SerializeField] private float walkSpeed = 5f;
	[SerializeField] private float jumpForce = 12f;
	
	[SerializeField] private LayerMask jumpableGround;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
		ground = GetComponent<BoxCollider2D>();
		animator = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		dirX = Input.GetAxis("Horizontal");
		player.velocity = new Vector2(walkSpeed * dirX, player.velocity.y);
		
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
			player.velocity = new Vector2(player.velocity.x, jumpForce);
		}

		UpdateAnimation();
    }

	private void UpdateAnimation()
	{
		if (dirX > 0f)
		{
			animator.SetBool("running", true);
			sprite.flipX = false;
		}
		else if (dirX < 0f)
		{
			animator.SetBool("running", true);
			sprite.flipX = true;
		}
		else
		{
			animator.SetBool("running", false);
		}
	}
	
	private bool IsGrounded()
	{
		return Physics2D.BoxCast(ground.bounds.center, ground.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
	}
}
