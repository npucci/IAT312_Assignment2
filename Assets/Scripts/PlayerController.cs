using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	public float speed = 15f;
	public float jumpSpeed = 1f;
	public float maxVelocityX = 8f;
	public float movementXEasing = 0.2f;

    public bool enabledMove;

	private SpriteRenderer sr;
	private Animator anim;
	private bool movingR = false;
	private bool movingL = false;
	private bool jumping = false;
	private Timer jumpTimer;



	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		sr.flipX = true;
		anim = GetComponent<Animator> ();
//		anim.CrossFade("player_idle", 0f);
		jumpTimer = GetComponent<Timer> ();
		jumpTimer.setTimer(0.1f);
	}

	void Update () {
        if (enabledMove == false) {
            return;
        }

		//Player's movement based on WASD keys and Space Bar
		if (Input.GetKeyDown (KeyCode.D)) {
			movingR = true;
			anim.CrossFade("player_run", 0f);

        } else if (Input.GetKeyDown (KeyCode.A)) {
			movingL = true;
			anim.CrossFade("player_run", 0f);
		} else if (Input.GetKeyUp (KeyCode.D)) {
			movingR = false;
			anim.CrossFade ("player_idle", 0f);
		} else if (Input.GetKeyUp (KeyCode.A)) {
			movingL = false;
			anim.CrossFade ("player_idle", 0f);
		} 

		if (Input.GetKeyDown (KeyCode.Space) && !jumping) {
			jumping = true;
			jumpTimer.startTimer();
			anim.CrossFade ("player_jump", 0f);
		}

		if(jumpTimer.stopped() && rb.velocity.y == 0) {
			if (jumping && !movingR && !movingL) {
				anim.CrossFade ("player_idle", 0f);
			}
			jumping = false;
		}

	}

	void FixedUpdate() {
		float jSpeed = 0f;
		float xSpeed = 0f;

		if (movingR) {
			xSpeed = speed;
			sr.flipX = true;

		} 

		else if (movingL) {
			xSpeed = -speed;
			sr.flipX = false;
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

		// add force to rigidbody for horizontal movement
		rb.AddForce(moveX, ForceMode2D.Force);
		if (Mathf.Abs (rb.velocity.x) > maxVelocityX) {
			if (rb.velocity.x > 0) {
				rb.velocity = new Vector2 (maxVelocityX, rb.velocity.y);
			}

			else if (rb.velocity.x < 0) {
				rb.velocity = new Vector2 (-maxVelocityX, rb.velocity.y);
			}
		}

		// add imulse force to rigidbody for vertical movement
		rb.AddForce(moveY, ForceMode2D.Impulse);
	}

	// Use this for initialization
	public Vector3 getposition(){
		return transform.position;
	}
}