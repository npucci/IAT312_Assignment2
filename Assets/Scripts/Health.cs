using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float HP = 10;
	// still need to add flashing color change for when GameObject is hit
	public void decreaseHp(float damage){
		HP -= damage;
	}

	public void increaseHp(float recovery){
		HP += recovery;
	}

	public bool dead() {
		return HP <= 0;
	}
}
