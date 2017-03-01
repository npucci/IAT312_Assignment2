using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//test
public class Enemy : MonoBehaviour {
	public PlayerController player;
	public float speed;
	public float distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (gameObject.transform.localPosition, player.getposition ()) < distance) {
			transform.localPosition = Vector3.MoveTowards (gameObject.transform.localPosition, player.getposition (), speed);
		}
	}
}
