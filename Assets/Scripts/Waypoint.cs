using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour {
	public int loadNextLevel;

	public void OnTriggerStay2D(Collider2D other) {
    	if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.W)) {
        	Application.LoadLevel(loadNextLevel);
		} 
    }
}
