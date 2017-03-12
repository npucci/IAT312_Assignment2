using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueActivator : MonoBehaviour {
	public string name;
	public Image portrait;
	private NarrativeEngine narrativeEngine;

	void Start () {
		portrait = GetComponent<Image> ();
        narrativeEngine = FindObjectOfType<NarrativeEngine>();
	}

	void Update () {}

    void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player" && Input.GetKeyDown(KeyCode.E)) { 
			narrativeEngine.playDialogue (this);
        }
    }

	void OnTriggerStay2D(Collider2D other) {
		if (other.name == "Player" && Input.GetKeyDown(KeyCode.E)) { 
			narrativeEngine.playDialogue (this);
		}
	}

    void OnTriggerExit2D(Collider2D other) {}
}
