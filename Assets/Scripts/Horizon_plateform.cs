using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizon_plateform : MonoBehaviour {
	private Vector3 pos;
	private Vector3 origin;
	private int direction = 1; // 1 == right, -1 == left

	public bool startGoingRight = true;
	public float leftborder,rightborder,speed;

	void Start() {
		origin = transform.position;
		if (startGoingRight) {
			direction = 1;
		} else {
			direction = -1;
		}
	}

	// Update is called once per frame
	void Update () {
		pos = this.transform.position;
		if (pos.x <= origin.x + leftborder) {
			direction = -1;
		}
		else if (pos.x >= origin.x + rightborder) {
			direction = 1;
		}
		transform.Translate (Vector2.left * direction * speed * Time.deltaTime);
	}

	// make objects resting on top to move with platform
	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.position.y > transform.position.y + 1f) {
			other.transform.parent = transform;
		}
	}

	// if player jumps while still on the moving platform, the player will still move 
	// relative to the horizontal position of the platform
	void OnTriggerExit2D(Collider2D other) {
		other.transform.parent = null;
	}
}