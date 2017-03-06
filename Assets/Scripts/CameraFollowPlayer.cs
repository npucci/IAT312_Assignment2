/* Team Solo Players
 * IAT 312
 * Date Created: February 11, 2017
 * Purpose: This script is used for the MainCamera to follow the Player GameObject
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
	private Transform player; // keeps track of Player position

	public float adjustX = 0f;
	public float adjustY = 0f;

	void Start () {
		player = GameObject.Find ("Player").GetComponent<Transform> ();
	}

	void Update () {
		if (player != null) {
			transform.position = new Vector3 (player.position.x + adjustX, player.position.y + adjustY, transform.position.z); // adjust camera lower
		}
	}
}