using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float maxHP = 10f;
	public float damageColorTime = 0.5f;
	private float HP;
	private Timer damageTimer;
	private SpriteRenderer sr;

	void Start() {
		HP = maxHP;
		sr = GetComponent<SpriteRenderer> ();
		damageTimer = new Timer (damageColorTime);
	}

	void Update() {
		damageTimer.updateTimer (Time.deltaTime);
		if (!damageTimer.stopped ()) {
			sr.color = new Color (255f, 0f, 0f, 255f);
		} else {
			sr.color = new Color (255f, 255f, 255f, 255f);
		}
	}

	// still need to add flashing color change for when GameObject is hit
	public void decreaseHp(float damage){
		HP -= damage;
		damageTimer.restartTimer ();
	}

	public void increaseHp(float recovery){
		if (recovery + HP >= maxHP) {
			HP = maxHP;
		}
		else {
			HP += recovery;
		}
	}

	public bool dead() {
		return HP <= 0;
	}

	public void resetHealth() {
		HP = maxHP;
	}

	public float getHealth() {
		return HP;
	}

	public float getMaxHealth() {
		return maxHP;
	} 
}
