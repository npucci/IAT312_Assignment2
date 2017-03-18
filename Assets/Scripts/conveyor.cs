using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor : MonoBehaviour {

	public PlayerController player;
	public bool toright;
	public float speed;

	void OnCollisionEnter2D(Collision2D col)
	{
		
		player.setconveyor_speed (speed);
		if (toright) {
			player.mover ();
		} 
		else {
			player.moveL ();
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		player.stop_fromconveyor ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
