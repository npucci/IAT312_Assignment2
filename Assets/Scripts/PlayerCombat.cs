using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Combat {
	public float attackForce = 1f;
	private SpriteRenderer sr;
	private PlayerController pc;
	private AudioSource audioSource;
	private bool hasClicked = false;

	void Start () {
		base.Start ();
		sr = GetComponent<SpriteRenderer> ();
		pc = GetComponent<PlayerController> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		if (attacking) {
			base.attackTimer.updateTimer (Time.deltaTime);
		}

		if (base.attackTimer.stopped ()) {
			base.attacking = false;
		}

		if (pc.isPlayerMovementEnabled () && Input.GetMouseButtonDown (0) && base.attackTimer.stopped()) {
			hasClicked = true;
			base.attacking = true;
			base.attackTimer.startTimer ();
		} else {
			hasClicked = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (hasClicked && !base.attackTimer.stopped () && coll.gameObject.name.Contains("Enemy") && !sr.flipX && transform.position.x < coll.transform.position.x) {
			audioSource.Play ();
			coll.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
			applyForce (coll.gameObject.GetComponent<Rigidbody2D> ());
		}

		else if (hasClicked && !base.attackTimer.stopped () &&  coll.gameObject.name.Contains("Enemy") && sr.flipX && transform.position.x > coll.transform.position.x) {
			audioSource.Play ();
			coll.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
			applyForce (coll.gameObject.GetComponent<Rigidbody2D> ());
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if (hasClicked && !base.attackTimer.stopped () &&  coll.gameObject.name.Contains("Enemy") && !sr.flipX && transform.position.x < coll.transform.position.x) {
			Debug.Log (hasClicked);
			audioSource.Play ();
			coll.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
			applyForce (coll.gameObject.GetComponent<Rigidbody2D> ());
		}

		else if (hasClicked && !base.attackTimer.stopped () &&  coll.gameObject.name.Contains("Enemy") && sr.flipX && transform.position.x > coll.transform.position.x) {
			Debug.Log (hasClicked);
			audioSource.Play ();
			coll.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
			applyForce (coll.gameObject.GetComponent<Rigidbody2D> ());
		}
	}

	private void applyForce(Rigidbody2D rb) {
		int direction = 1;
		if (gameObject.GetComponent<SpriteRenderer> ().flipX) {
			direction = -1;
		} else {
			direction = 1;
		}
		Vector2 force = new Vector2 (direction * base.attackDamage * attackForce, base.attackDamage * attackForce);
		rb.AddForce (force, ForceMode2D.Impulse);
	}

	public bool isAttacking() {
		return base.attacking;
	}
}

