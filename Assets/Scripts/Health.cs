using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float HP = 10;

	public void decreaseHp(float damage){
		HP -= damage;
		Debug.Log (transform.name + " Health: " + HP);
	}

	public void increaseHp(float recovery){
		HP += recovery;
	}

	public bool dead() {
		return HP <= 0;
	}
}
