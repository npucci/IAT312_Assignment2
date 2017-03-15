using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour {
	private GameObject player;
	private Vector3 playerRespawnPoint;
	private string currentSceneName;

	public float fallDamage = 1f;
	public float deathDepth = -10f;

	// Use this for initialization
	void Start () {
		currentSceneName = SceneManager.GetActiveScene ().name;
		player = GameObject.Find ("Player");
		findCorrectRespawnPoint ();
		spawnPlayer ();

	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y <= deathDepth) {
			respawnPlayer ();
		}

		if (player.transform.GetComponent<Health> ().dead ()) {
			spawnPlayer ();
		}
	}

	private void findCorrectRespawnPoint () {
		string lastSceneName = player.GetComponent<PlayerController>().getLastSceneName ();

		if ((lastSceneName == "" || lastSceneName == "intro_cutscene") && currentSceneName == "level1") {
			playerRespawnPoint = GameObject.Find ("Entrance").GetComponent<Transform> ().position;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;

		} else {
			if (lastSceneName == "") {
				playerRespawnPoint = player.transform.position;
			} else {
				playerRespawnPoint = GameObject.Find ("Door To " + lastSceneName).GetComponent<Transform> ().position;
			}
		}
	}

	private void spawnPlayer () {
		if (player != null) {
			player.transform.position = playerRespawnPoint;
		}
	}

	private void respawnPlayer() {
		if (player != null) {
			player.GetComponent<Health> ().decreaseHp (fallDamage);
			player.transform.position = playerRespawnPoint;
		}
	}
}
