using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {
	public float attackDamage = 1f;
	public float attackPause = 0.5f;

	protected bool attacking = false;
	protected Timer attackTimer;

	void Start () {
		attackTimer = new Timer (attackPause);
	}
}
