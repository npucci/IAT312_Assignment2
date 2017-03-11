using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public PlayerController player;
	public float initialangle;
	public float speed;

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
