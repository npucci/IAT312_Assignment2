using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public static PlayerController instance; // for singleton object

	public float speed = 30f;
	public float jumpSpeed = 10f;
	public float maxVelocityX = 8f;
	public float movementXEasing = 0.6f;
	public string playerName = "Player";
	public Sprite portrait;

	private string lastSceneName = "";
	private bool enabledMove = true; // for dialogue system
	private bool grounded = false;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Health healthManager;
	private PlayerEvasion dash;
	private PlayerCombat attack; 
	private Animator anim;
	private bool movingR = false;
	private bool movingL = false;
	private bool spaceBar = false;
	private bool jumping = false;
	public bool conveyorR = false;
	public bool conveyorL = false;
	private float conveyor_speed;



	void Awake() {
		if (instance == null) {
			instance = this;
		}

		// check for if there is a multiple or pre-existing player object in a scene,
		// and destroys it, so that only the very first instantiation exists
		else if (instance != this) {
			Destroy (gameObject);
		}

		// tells Unity not to destroy this object
		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		healthManager = GetComponent<Health> ();
		dash = GetComponent<PlayerEvasion> ();
		attack = GetComponent<PlayerCombat> ();
		anim = GetComponent<Animator> ();
		portrait = sr.sprite;
	}

	void Update () {
		if (transform.parent == null) {
			DontDestroyOnLoad (gameObject);
		}

		// pause player movement while dialogue is running, if selected by Dialogue Manager
		if (!enabledMove) {
			movingR = false;
			movingL = false;
			jumping = false;
			anim.CrossFade ("player_idle", 0f);
			return;
		}

		//Player's movement based on WASD keys and Space Bar
		if (Input.GetKeyDown (KeyCode.D)) {
			movingR = true;
		} 
		if (Input.GetKeyDown (KeyCode.A)) {
			movingL = true;
		} 
		if (Input.GetKeyUp (KeyCode.D)) {
			movingR = false;
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			movingL = false;
		} 

		if ((Input.GetKeyDown (KeyCode.Space) && grounded)) {
			spaceBar = true;
		} 

		if (attack.isAttacking ()) {
			anim.CrossFade ("player_attack", 0f);
		} else if (dash.isDashing ()) {
			anim.CrossFade ("player_dash", 0f);
		} else if (jumping) {
			anim.CrossFade ("player_jump", 0f);
		} else if (grounded && (movingR || movingL) && !dash.isDashing ()) {
			anim.CrossFade ("player_run", 0f);
		} else if (grounded && !dash.isDashing ()) {
			anim.CrossFade ("player_idle", 0f);
		}

		if (conveyorR) {
			transform.Translate(Vector2.right * Time.deltaTime*conveyor_speed); 
			sr.flipX = false;
		} 

		else if (conveyorL) {
			transform.Translate(Vector2.left * Time.deltaTime*conveyor_speed); 
			sr.flipX = true;
		}
	}

	// updates only physics when necessary
	void FixedUpdate() {
		float jSpeed = 0f;
		float xSpeed = 0f;


		if (movingR) {
			xSpeed = speed;
			sr.flipX = false;
		} 

		else if (movingL) {
			xSpeed = -speed;
			sr.flipX = true;
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
			
		if (spaceBar) {
			jumping = true;
			jSpeed = jumpSpeed;
			spaceBar = false;
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
			
		rb.AddForce(moveY, ForceMode2D.Impulse);
	}

	public Vector3 getposition(){
		return transform.position;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (transform.position.y > other.transform.position.y) {
			grounded = true;
			jumping = false;
		}
	}

	void OnCollisionStay2D(Collision2D other) {
		if (transform.position.y > other.transform.position.y) {
			grounded = true;
			//jumping = false;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (transform.position.y > other.transform.position.y) {
			grounded = false;
		}
	}

	public void enablePlayerMovement(bool enable) {
		enabledMove = enable;
	}

	public bool isPlayerMovementEnabled() {
		return enabledMove;
	}

	public string getLastSceneName() {
		return lastSceneName;
	}

	public void setLastSceneName(string sceneName) {
		lastSceneName = sceneName;
	}
	public void mover(){
		conveyorR = true;
	}
	public void moveL(){
		conveyorL = true;
	}
	public void stop_fromconveyor(){
		conveyorR = false;
		conveyorL = false;
	}
	public void setconveyor_speed(float conveyorspeed){
		conveyor_speed = conveyorspeed;
	}

}
