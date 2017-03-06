using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	private Health playerHealth;
	private int healthIndex = 4; // 4 == full, 0 == empty
	public Sprite[] HPState;


	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("Player").GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Health betwen full and 3/4
		if (playerHealth.getHealth() <= playerHealth.getMaxHealth() && playerHealth.getHealth() > 3 * playerHealth.getMaxHealth() / 4) {
			healthIndex = 4;
		}

		// Health between 3/4 and 1/2
		else if (playerHealth.getHealth() <= 3 * playerHealth.getMaxHealth() / 4 && playerHealth.getHealth() > playerHealth.getMaxHealth() / 2) {
			healthIndex = 3;
		}

		// Health between 1/2 and 1/4
		else if (playerHealth.getHealth() <= playerHealth.getMaxHealth() / 2 && playerHealth.getHealth() > playerHealth.getMaxHealth() / 4) {
			healthIndex = 2;
		}

		// Health between 1/4 and 0
		else if (playerHealth.getHealth() <= playerHealth.getMaxHealth() / 4 && playerHealth.getHealth() > 0) {
			healthIndex = 1;
		}
		// Health equals or less to 0
		else if (playerHealth.getHealth() <= 0) {
			healthIndex = 0;
		}

		GetComponent<Image>().overrideSprite = HPState [healthIndex];

	}
}
