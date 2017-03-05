/* Team Solo Players
 * IAT 312
 * Assignment: Antlion Redesign
 * Date Created: February 11, 2017
 * Purpose: This script is used for the MainCamera to follow the Player GameObject
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
	private Transform player; // keeps track of Player position

	public float adjustX = 0f;

	void Start () {
		player = GameObject.Find ("Player").GetComponent<Transform> ();
		//player = GameObject.Find ("Antlion").GetComponent<Transform> ();	
	}

	void Update () {
		transform.position = new Vector3 (player.position.x + adjustX, transform.position.y, transform.position.z); // adjust camera lower
	}
}