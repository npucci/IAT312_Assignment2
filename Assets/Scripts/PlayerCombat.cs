using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Combat {
	public float attackForce = 1f;
	private SpriteRenderer sr;
	private PlayerController pc;

	void Start () {
		base.Start ();
		sr = GetComponent<SpriteRenderer> ();
		pc = GetComponent<PlayerController> ();
	}

	void Update () {
		base.attackTimer.updateTimer (Time.deltaTime);

		// if player is clicking the left mouse click, set attacking flag
		if (pc.isPlayerMovementEnabled() && base.attackTimer.stopped() && Input.GetMouseButtonDown (0)) {
			base.attacking = true;
		} else {
			base.attacking = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (attacking && coll.gameObject.name.Contains("Enemy") && sr.flipX && transform.position.x < coll.transform.position.x) {
			coll.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
			applyForce (coll.gameObject.GetComponent<Rigidbody2D> ());
			base.attackTimer.startTimer ();
		}

		else if (attacking && coll.gameObject.name.Contains("Enemy") && !sr.flipX && transform.position.x > coll.transform.position.x) {
			coll.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
			applyForce (coll.gameObject.GetComponent<Rigidbody2D> ());
			base.attackTimer.startTimer ();
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if (attacking && coll.gameObject.name.Contains("Enemy") && sr.flipX && transform.position.x < coll.transform.position.x) {
			coll.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
			applyForce (coll.gameObject.GetComponent<Rigidbody2D> ());
			base.attackTimer.startTimer ();
		}

		else if (attacking && coll.gameObject.name.Contains("Enemy") && !sr.flipX && transform.position.x > coll.transform.position.x) {
			coll.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
			applyForce (coll.gameObject.GetComponent<Rigidbody2D> ());
			base.attackTimer.startTimer ();
		}
	}

	void applyForce(Rigidbody2D rb) {
		int direction = 1;
		if (gameObject.GetComponent<SpriteRenderer> ().flipX) {
			direction = 1;
		} else {
			direction = -1;
		}
		Vector2 force = new Vector2 (direction * base.attackDamage * attackForce, base.attackDamage * attackForce);
		rb.AddForce (force, ForceMode2D.Impulse);
		base.attackTimer.startTimer ();
	}
}

