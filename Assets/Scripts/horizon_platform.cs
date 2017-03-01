using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizon_plateform : MonoBehaviour {

	public Vector3 pos;
	private int walkstate;
	public float leftborder,rightborder,speed;

	void Start () {
		walkstate = 1;
	}

	// Update is called once per frame
	void Update () {
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
}