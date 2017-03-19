using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_enemy : MonoBehaviour {
	
	public PlayerController player;
	public float leftborder,rightborder,speed,jump_height,react_time,distance;
	public float attackDamage = 1f;

	private Vector3 pos;
	private int walkstate;
	private Collider2D coll;
	private Health healthManager;
	private Vector3 player_pos;
	private bool jump,follow,react;

	public IEnumerator wait()
	{
		yield return new WaitForSeconds(react_time);
		react = true;
	}

	void Start () {
		healthManager = GetComponent<Health> ();
		jump = false;
		follow = false;
		walkstate = 1;
		react = true;
	}

	// Update is called once per frame
	void Update () {
		if(healthManager.dead()) {
			Destroy(this);
		}

		if (Vector3.Distance (gameObject.transform.localPosition, player.getposition ()) < distance) {
			if(react==true){
				jump = true;
				react = false;
			}
			follow = true;
		}
		if (Vector3.Distance (gameObject.transform.localPosition, player.getposition ()) > distance) {
			jump = false;
			follow = false;
		} 
		pos = this.transform.position;
		if (walkstate == 1) {
			if (pos.x > leftborder) {
				transform.Translate (Vector2.left * speed/10);
			} 
			else {
				walkstate = 2;
			}
		}
		//pos = this.transform.position;
		if (walkstate == 2) {

			if (pos.x < rightborder) {
				transform.rotation = Quaternion.AngleAxis (180, Vector3.down);
				transform.Translate (Vector2.left * speed/10);
			} 
			else {
				transform.rotation = Quaternion.AngleAxis (0, Vector3.down);
				walkstate = 1;
			}
		}

			
	}
	void FixedUpdate() {
		if (jump == true) {
			transform.Translate (Vector2.up * jump_height);
			jump = false;
			StartCoroutine(wait());
		}
		if (follow == true) {
			if (player.getposition ().x < pos.x) {
				transform.Translate (Vector2.left * speed/100);
			}
			if (player.getposition ().x > pos.x) {
				transform.Translate (Vector2.right * speed/100);
			}
			
			
		}
	}
		
	void OnTriggerEnter2D(Collider2D Coll)
	{
		if (Coll.gameObject.name == "Player") {
			player.GetComponent<Health>().decreaseHp (attackDamage);
		}
	}

	void OnTriggerStay2D(Collider2D Coll)
	{
		if (Coll.gameObject.name == "Player") {
			Coll.gameObject.GetComponent<Health>().decreaseHp(attackDamage/10);
		}
	}
}
