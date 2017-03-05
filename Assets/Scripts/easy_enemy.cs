using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easy_enemy : MonoBehaviour {
	private Vector3 pos;
	private Vector3 origin;
	private int direction;
	private Rigidbody2D rb;
	private SpriteRenderer sr;

	public bool startGoingRight = true;
	public float attackDamage = 1f;
	public float leftborder, rightborder, speed;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		origin = transform.position;
		if (startGoingRight) {
			direction = 1;
		} else {
			direction = -1;
		}
	}
		
	void Update () {
		pos = rb.transform.position;
		if (pos.x < origin.x + leftborder) {
			direction = 1;
		}

		if (pos.x > origin.x + rightborder) {
			direction = -1;
		}

		if (direction == 1) {
			sr.flipX = true;
		} else {
			sr.flipX = false;
		}

		rb.transform.Translate (Vector2.right * direction * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D Coll)
	{
		if (Coll.gameObject.name == "Player") {
			Coll.gameObject.GetComponent<PlayerController>().decrease_Hp(attackDamage);
		}
	}
}