using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private bool leftArrow = false; // detect left arrow
	private bool rightArrow = false; // detect right arrow
	private bool downArrow = false; // detect left arrow
	private bool upArrow = false; // detect right arrow
	private bool faceright = false; 
	private bool faceleft = true; 
	private bool faceup = false;
	private bool facedown = false;

	public float speed;
	// Use this for initialization
	public Vector3 getposition(){
		return transform.position;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow)){
			leftArrow = true;
			rightArrow = false;
		} 

		else if (Input.GetKey(KeyCode.RightArrow)){
			rightArrow = true;
			leftArrow = false;
		} 

		else {
			leftArrow = false;
			rightArrow = false;
		}

		// vertical movement input checks
		if (Input.GetKey(KeyCode.DownArrow)){
			downArrow = true;
			upArrow = false;
		}

		else if (Input.GetKey(KeyCode.UpArrow)){
			upArrow = true;
			downArrow = false;
		}

		else {
			downArrow = false;
			upArrow = false;
		}
		
	}

	void FixedUpdate() {
		float moveX = 0f;

		if (leftArrow) {
			transform.Translate(Vector2.left * Time.deltaTime*speed);
		} 

		if (rightArrow) {
			transform.Translate(Vector2.right * Time.deltaTime*speed);
		} 
		if (upArrow) {
			transform.Translate(Vector2.up * Time.deltaTime*speed);
		}
		if (downArrow) {
			transform.Translate(Vector2.down* Time.deltaTime*speed);
		}
}
}