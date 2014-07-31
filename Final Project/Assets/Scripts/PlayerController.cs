using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]

public class PlayerController : Player {
	// Player
	public float speed = 10;
	public float acceleration = 30;
	public float gravity = 23;
	
	// Jumping
	public float jumpHeight = 13;
	
	private bool ableToDoubleJump = true;
	
	// Sliding
	public float slideDeceleration = 10;
	public float slideCenterX = 0;
	public float slideCenterY = 0.35f;
	public float slideCenterZ = 0;
	public float slideSizeX = 0.7f;
	public float slideSizeY = 0.7f;
	public float slideSizeZ = 1f;
	
	private float intiateSlideThreshold = 1; // Always want this to be above speed
	
	// System
	private float animationSpeed;
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	private float moveDirX;
	
	// Player States
	private bool jumping;
	private bool sliding;
	private bool stopSliding;
	
	// Components
	private PlayerPhysics playerPhysics;
	private Animator animator;
	private GameManager manager;
	
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		animator = GetComponent<Animator>();
		manager = Camera.main.GetComponent<GameManager>();
	}
	
	void Update () {
		// Reset the acceleration upon a collision
		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		#region When Player is Grounded
		// Player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			
			// Jump logic
			if (jumping) {
				jumping = false;
				ableToDoubleJump = true;
				
				animator.SetBool("Jumping", false);
			}
			
			// Slide logic
			if (sliding) {
				if (Mathf.Abs(currentSpeed) < .25f || stopSliding) {
					animator.SetBool("Sliding", false);
					stopSliding = false;
					sliding = false;
					
					playerPhysics.ResetCollider();
				}
			}
			
			// Slide Input
			if (Input.GetButtonDown("Slide")) {
				if (Mathf.Abs (currentSpeed) > intiateSlideThreshold) {
					sliding = true;
					animator.SetBool("Sliding", true);
					targetSpeed = 0;
					
					playerPhysics.SetCollider(new Vector3(slideSizeX, slideSizeY, slideSizeZ), new Vector3(slideCenterX, slideCenterY, slideCenterZ));
				}
			}
		}
		#endregion
		
		// Jump Input
		if (Input.GetButtonDown("Jump")) {
			// Player must be on ground or has only jumped once in order to jump
			if (playerPhysics.grounded) {
				if (sliding) {
					stopSliding = true;
				} else {
					Jump();
				}
			} else if (ableToDoubleJump) {
				Jump();
				
				ableToDoubleJump = false;
			}
		}
		
		// Set the animator parameters
		animationSpeed = IncrementTowards(animationSpeed, Mathf.Abs(targetSpeed), acceleration);
		animator.SetFloat("Speed", animationSpeed);
		
		// Player Input
		if (!sliding) {
			targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
			
			// Face Direction
			float moveDirection = Input.GetAxisRaw("Horizontal");
			
			if (moveDirection != 0) {
				if (moveDirection < 0) {
					transform.eulerAngles = Vector3.up * 180;
				} else {
					transform.eulerAngles = Vector3.zero;
				}
			}
		} else {
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed, slideDeceleration);
		}
		
		// Set amount to move
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		
		playerPhysics.Move(amountToMove * Time.deltaTime);
	}
	
	private void Jump() {
		amountToMove.y = jumpHeight;
		animator.SetBool("Jumping", true);
		jumping = true;
	}
	
	#region Trigger Events
	private void OnTriggerEnter(Collider c) {
		Debug.Log ("Player Trigger");
	
		if (c.tag == "Checkpoint") {
			manager.SetCheckpoint(c.transform.position);
		}
		if (c.tag == "Finish") {
			manager.EndLevel();
		}
	}
	#endregion
	
	private float IncrementTowards(float n, float target, float a) {
		float direction;
		
		if (n == target) {
			return n;	
		} else {
			direction = Mathf.Sign(target - n);
			
			n += a * Time.deltaTime * direction;
			
			if (direction == Mathf.Sign (target - n)) {
				return n;
			} else {
				return target;
			}
		}
	}
}