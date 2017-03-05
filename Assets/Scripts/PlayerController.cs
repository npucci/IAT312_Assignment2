using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 30f;
	public float jumpSpeed = 10f;
	public float maxVelocityX = 8f;
	public float movementXEasing = 0.6f;
	public bool enabledMove = false; // for dialogue system
	public float HP = 10f;

	private bool grounded = false;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Animator anim;
	private bool movingR = false;
	private bool movingL = false;
	private bool jumping = false;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		sr.flipX = true;
		anim = GetComponent<Animator> ();
		HP = 4;  //set the initial HP
	}

	void Update () {
		//Player's movement based on WASD keys and Space Bar
		if (Input.GetKeyDown (KeyCode.D)) {
			movingR = true;
			anim.CrossFade ("player_run", 0f);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			movingL = true;
			anim.CrossFade ("player_run", 0f);
		} else if (Input.GetKeyUp (KeyCode.D)) {
			movingR = false;
			anim.CrossFade ("player_idle", 0f);
		} else if (Input.GetKeyUp (KeyCode.A)) {
			movingL = false;
			anim.CrossFade ("player_idle", 0f);
		}

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			jumping = true;
			anim.CrossFade ("player_jump", 0f);
		}
	}

	// updates only physics when necessary
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
		if (jumping) {//jumping && !jumpTimer.stopped()) {
			jSpeed = jumpSpeed;
			//jumping = false;
		}
			
		Vector2 moveX = new Vector2(xSpeed, 0);     
		Vector2 moveY = new Vector2(0, jSpeed);   

		// add force to rigidbody for horizontal movement
		rb.AddForce(moveX, ForceMode2D.Force);
		// make sure player does not exceed the max velocity limit, and if so, bound them by that value
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
		//rb.velocity = new Vector2(xSpeed, jSpeed); 
	}



	void OnCollisionStay2D(Collision2D other) {
		if (transform.position.y > other.transform.position.y) {
			grounded = true;
			jumping = false;
		}
	}
		
	void OnCollisionExit2D(Collision2D other) {
		grounded = false;
	}

	public Vector3 getposition(){
		return transform.position;
	}
	public void decrease_Hp(float attackDamage){
		HP -= attackDamage;
		//Debug.Log ("Player Health: " + HP);
	}
}