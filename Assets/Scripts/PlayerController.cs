using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	public float speed = 10f;
	public float jumpSpeed = 1f;
	public float maxVelocityX = 8f;
	public float movementXEasing = 0.2f;

	private bool movingR = false;
	private bool movingL = false;
	private bool jumping = false;
	private Timer jumpTimer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jumpTimer = GetComponent<Timer> ();
		jumpTimer.setTimer(0.1f);
	}

	void Update () {
		//Player's movement based on WASD keys and Space Bar
		if (Input.GetKeyDown (KeyCode.D)) {
			movingR = true;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			movingL = true;
		} else if (Input.GetKeyUp (KeyCode.D)) {
			movingR = false;
		} else if (Input.GetKeyUp (KeyCode.A)) {
			movingL = false;
		} 

		if (Input.GetKeyDown (KeyCode.Space) && !jumping) {
			jumping = true;
			jumpTimer.startTimer();
		}

		if(jumpTimer.stopped() && rb.velocity.y == 0) {
			jumping = false;
		}

	}

	void FixedUpdate() {
		float jSpeed = 0f;
		float xSpeed = 0f;

		if (movingR) {
			xSpeed = speed;
		} 

		else if (movingL) {
			xSpeed = -speed;
		} 

		// if player is not moving, slow down and stop
		else {
			if (Mathf.Abs (rb.velocity.x) - movementXEasing < 0) {
				rb.velocity = new Vector2 (0, rb.velocity.y);
			} 

			else if (rb.velocity.x > 0) {
				rb.velocity = new Vector2 (rb.velocity.x - movementXEasing, rb.velocity.y);
			} 

			else if (rb.velocity.x < 0) {
				rb.velocity = new Vector2 (rb.velocity.x + movementXEasing, rb.velocity.y);
			}
		}

		// if player is jumping
		if (jumping && !jumpTimer.stopped()) {
			jSpeed = jumpSpeed;
		}


		Vector2 moveX = new Vector2(xSpeed, 0);     
		Vector2 moveY = new Vector2(0, jSpeed);   

		rb.AddForce(moveX, ForceMode2D.Force);
		if (Mathf.Abs (rb.velocity.x) > maxVelocityX) {
			if (rb.velocity.x > 0) {
				rb.velocity = new Vector2 (maxVelocityX, rb.velocity.y);
			}

			else if (rb.velocity.x < 0) {
				rb.velocity = new Vector2 (-maxVelocityX, rb.velocity.y);
			}
		}

		rb.AddForce(moveY, ForceMode2D.Impulse);
	}
}
