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

	private enum MovementState { idle, running, jumping, falling };

	[SerializeField] private AudioSource jumpSoundEffect;
	
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
			jumpSoundEffect.Play();
			player.velocity = new Vector2(player.velocity.x, jumpForce);
		}

		UpdateAnimation();
    }

	private void UpdateAnimation()
	{
		MovementState state;

		if (dirX > 0f)
		{
			state = MovementState.running;
			sprite.flipX = false;
		}
		else if (dirX < 0f)
		{
			state = MovementState.running;
			sprite.flipX = true;
		}
		else
		{
			state = MovementState.idle;
		}

		if (player.velocity.y > .1f)
		{
			state = MovementState.jumping;
		}
		else if (player.velocity.y < -.1f)
		{
			state = MovementState.falling;
		}

		animator.SetInteger("state", (int)state);
	}
	
	private bool IsGrounded()
	{
		return Physics2D.BoxCast(ground.bounds.center, ground.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
	}
}
