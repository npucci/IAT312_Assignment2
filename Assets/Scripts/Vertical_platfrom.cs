using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical_platfrom : MonoBehaviour {

	private Vector3 pos;
	private int walkstate;
	public float topborder,bottomborder,speed;

	void Start () {
		walkstate = 1;
	}

	// Update is called once per frame
	void Update () {
		pos = this.transform.position;
		if (walkstate == 1) {
			if (pos.y > bottomborder) {
				transform.Translate (Vector2.down * speed/10);
			} 
			else {
				walkstate = 2;
			}
		}
		//pos = this.transform.position;
		if (walkstate == 2) {

			if (pos.y < topborder) {

				transform.Translate (Vector2.up * speed/10);
			} 
			else {
				walkstate = 1;
			}
		}
	}
}