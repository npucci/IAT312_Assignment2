using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easy_enemy : MonoBehaviour {
	private Vector3 pos;
	private Vector3 origin;
	private int direction;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Health healthManager;

	public bool startGoingRight = true;
	public float attackDamage = 1f;
	public float leftborder, rightborder, speed;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		healthManager = GetComponent<Health> ();
		origin = transform.position;
		if (startGoingRight) {
			direction = 1;
		} else {
			direction = -1;
		}
	}
		
	void Update () {
		if(healthManager.dead()) {
			Destroy(gameObject);
		}

		pos = rb.transform.position;
		if (pos.x < origin.x + leftborder) {
			direction = 1;
		}

		if (pos.x > origin.x + rightborder) {
			direction = -1;
		}

		// flip sprite across the x axis so that sprite faces the correct direction of movement
		if (direction == 1) {
			sr.flipX = true;
		} else {
			sr.flipX = false;
		}

		rb.transform.Translate (Vector2.right * direction * speed * Time.deltaTime);
	}
}