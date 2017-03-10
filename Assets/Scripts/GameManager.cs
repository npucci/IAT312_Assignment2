using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	static public GameManager instance;

	public GameObject player; 

	private string lastSceneName = "";

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}


		DontDestroyOnLoad (this.gameObject);
	}

	public string getLastSceneName() {
		return lastSceneName;
	}

	public void setLastSceneName(string sceneName) {
		lastSceneName = sceneName;
	}
}
