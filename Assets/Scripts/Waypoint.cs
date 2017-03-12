using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour {
	public string nextSceneName;

	public void OnTriggerStay2D(Collider2D other) {
    	if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.W)) {
			int i = -1;
			switch (nextSceneName) {
			case "level1":
				i = 2;	
				break;
			case "level2":
				i = 3;	
				break;
			case "level3":
				i = 4;	
				break;
			default:
				break;
			}

			if (SceneManager.GetActiveScene ().name != nextSceneName && i > -1) {
				FindObjectOfType<GameManager> ().setLastSceneName (SceneManager.GetActiveScene().name);
				GameObject player = FindObjectOfType<PlayerController> ().gameObject;
				player.transform.parent = null;
				DontDestroyOnLoad (player);
				SceneManager.LoadScene (i);
			}
		} 
    }
}
