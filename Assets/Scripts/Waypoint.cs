using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour {
	public string nextSceneName;
	public bool locked = false;
	public string keyItemName = "none";

	private Image portrait;
	private PlayerController player;
	private NarrativeEngine narrativeEngine;


	public void Start() {
		portrait = GetComponent<Image> ();
		narrativeEngine = FindObjectOfType<NarrativeEngine>();
		player = FindObjectOfType<PlayerController> ().GetComponent<PlayerController> ();
	}

	public void Update() {
		if (player == null) {
			player = FindObjectOfType<PlayerController> ().GetComponent<PlayerController> ();
		}
	}

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

			if (locked && player.GetComponent<Inventory> ().hasItem (keyItemName)) {
				locked = false;
			}

			if (!locked && SceneManager.GetActiveScene ().name != nextSceneName && i > -1) {
				player.setLastSceneName (SceneManager.GetActiveScene ().name);
				player.transform.parent = null;
				DontDestroyOnLoad (player);
				SceneManager.LoadScene (i);
			} else {
				narrativeEngine.playDialogue (portrait.sprite, "Door (Locked)");
			}
		} 
    }
}
