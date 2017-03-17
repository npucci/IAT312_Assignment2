using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping_platform : MonoBehaviour {
	public PlayerController player;
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player") {
			player.keepjumping();
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
