using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_obstacle : MonoBehaviour {
	public PlayerController player;
	public float height;
	public float speed,distance;
	public bool fall,lift;
	public PlayerController Player;
	public float attackDamage;

	// Use this for initialization
	void Start () {
		lift = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player") {
			col.gameObject.GetComponent <Health>().decreaseHp(attackDamage);
		}


	}
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(player.getposition ().x-gameObject.transform.localPosition.x) < distance) {
			fall = true;
		}


	}
	void FixedUpdate(){
		if (fall) {
			transform.Translate (Vector3.down * speed * Time.deltaTime);
			fall = false;
			//lift = true;
		}
		if (lift) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
			lift = false;
		}




	}
}
