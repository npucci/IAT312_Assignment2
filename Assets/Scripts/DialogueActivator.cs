using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueActivator : MonoBehaviour {
	public string characterName;
	public Sprite portrait;
	private NarrativeEngine narrativeEngine;

	void Start () {
		portrait = GetComponent<SpriteRenderer> ().sprite;
        narrativeEngine = FindObjectOfType<NarrativeEngine>();
	}

    void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player" && Input.GetKeyDown(KeyCode.E)) { 
			narrativeEngine.playDialogue (portrait, characterName);
        }
    }

	void OnTriggerStay2D(Collider2D other) {
		if (other.name == "Player" && Input.GetKeyDown(KeyCode.E)) { 
			narrativeEngine.playDialogue (portrait, characterName);
		}
	}
}
