using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {
	private GameObject player;
	private GameObject playerRespawnPoint;

	public float deathDepth = -10f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			GameObject child = transform.GetChild (i).gameObject;
			if (child.name.Contains ("Player Respawn Point")) {
				playerRespawnPoint = child;
			}
		}

		player = GameObject.Find ("Player");
		spawnPlayer ();

	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y <= deathDepth) {
			respawnPlayer ();
		}

		if (player.transform.GetComponent<Health> ().dead ()) {
			respawnPlayer ();
			player.transform.GetComponent<Health> ().resetHealth ();
		}
	}

	private void spawnPlayer () {
		if (player != null && playerRespawnPoint != null) {
			player.transform.position = playerRespawnPoint.transform.position;
		}
	}

	private void respawnPlayer() {
		spawnPlayer();
	}
}
