using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour {
	public float distanceAngle = 90f;
	public bool clockwise = true;
	public float speed;

	private float distanceTraveled = 0f;
	private bool movement = true;

	void Update () {
		int direction = 1;
		if (clockwise) {
			direction = -1;
		}

		if (movement && distanceTraveled < distanceAngle) {
			distanceTraveled += speed;
			transform.Rotate (new Vector3 (0, 0, direction * speed));
		}
	}

	public void stopMovement () {
		movement = false;
	}

	public void startMovement () {
		movement = true;
	}

	/*
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player") {
			if (damage_cause) {
				col.gameObject.GetComponent <Health> ().decreaseHp (attackDamage);
			}
		}
	}
	*/
}
