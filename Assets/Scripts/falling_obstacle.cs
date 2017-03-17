using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_obstacle : MonoBehaviour {
	public PlayerController player;
	public float height;
	public float speed,distance;
	public bool fall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(player.getposition ().x-gameObject.transform.localPosition.x) < distance) {
			fall = true;
		}

		else {
			fall = false;
		}

	}
	void FixedUpdate(){
		if (fall) {
			transform.Translate(Vector3.down * speed *Time.deltaTime);
		}

	}
}
