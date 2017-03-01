using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavoir : MonoBehaviour {

    public float speed;
    public float jumpSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));     //Player's movement based on WASD or Arrow keys
        GetComponent<Rigidbody2D>().AddForce(move * speed);        //Update Player's movement
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
    }
}
