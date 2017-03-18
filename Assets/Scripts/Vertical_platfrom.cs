using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical_platfrom : MonoBehaviour {
	private Vector3 pos;
	private Vector3 origin;
	private int direction; // describes the direction of movement, up == 1, down == -1
	private bool movement = true;

	public bool startGoingUp = true;
	public float topborder,bottomborder,speed;

	void Start () {
		origin = transform.position;
		if (startGoingUp) {
			direction = 1;
		} else {
			direction = -1;
		}
	}

	// Update is called once per frame
	void Update () {
		pos = this.transform.position;

		if (pos.y >= origin.y + topborder) {
				direction = -1;
		}

		else if (pos.y <= origin.y + bottomborder) {
				direction = 1;
		}

		if (movement) { 
			transform.Translate (Vector3.up * direction * speed * Time.deltaTime);
		}
	}

	// make objects resting on top to move with platform
	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.position.y > transform.position.y + 1f) {
			other.transform.parent = transform;
		}
	}

	// if player jumps off platform, they no longer move with platform
	void OnTriggerExit2D(Collider2D other) {
		other.transform.parent = null;
	}

	public void stopMovement () {
		movement = false;
	}

	public void startMovement () {
		movement = true;
	}
}