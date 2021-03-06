﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : Combat {

	void Update() {
		base.attackTimer.updateTimer (Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!coll.isTrigger && base.attackTimer.stopped() && coll.gameObject.name == "Player") {
			coll.gameObject.GetComponent<Health>().decreaseHp(attackDamage);
			base.attackTimer.startTimer ();
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if (!coll.isTrigger && base.attackTimer.stopped() && coll.gameObject.name == "Player") {
			coll.gameObject.GetComponent<Health>().decreaseHp(attackDamage);
			base.attackTimer.startTimer ();
		}
	}
}
