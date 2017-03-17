using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public Health player;
	public float initialangle;
	public float speed;
	public bool damage_cause;
	public float attackDamage;


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player") {
			if (damage_cause) {
				col.gameObject.GetComponent <Health> ().decreaseHp (attackDamage);
			}
		}
	}
	// Use this for initialization
	void Start () {
		initialangle = 0;
	}

	// Update is called once per frame
	void Update () {
		
		if (transform.rotation.z<180) {
			transform.Rotate (new Vector3 (0, 0, initialangle+speed));
		}
		else if(transform.rotation.z == 180){
			transform.Rotate (new Vector3 (0, 0, initialangle-speed));
		}	

}
}
