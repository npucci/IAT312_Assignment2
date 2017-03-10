using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour {
	private GameObject player;
	private Transform playerRespawnPoint;
	private string currentSceneName;

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
			respawnPlayer ();
			player.transform.GetComponent<Health> ().resetHealth ();
		}
	}

	private void findCorrectRespawnPoint () {
		string lastSceneName = GameObject.Find("Game Manager").GetComponent<GameManager>().getLastSceneName ();

		if ((lastSceneName == "" || lastSceneName == "intro_cutscene") && currentSceneName == "level1") {
			playerRespawnPoint = GameObject.Find ("Entrance").GetComponent<Transform> ();
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;

		} else {
			playerRespawnPoint = GameObject.Find ("Door To " + lastSceneName).GetComponent<Transform> ();
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
