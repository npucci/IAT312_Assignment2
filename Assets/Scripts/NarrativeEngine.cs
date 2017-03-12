using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrativeEngine : MonoBehaviour {
	// singleton object
	static NarrativeEngine instance;

	// level entering flags
	private bool enteredLv1 = false;
	private bool enteredLv2 = false;
	private bool enteredLv3 = false;

	// dialogue flags
	private bool playerBeginningMonologue = false;
	private bool playerFirstMeetRemembrance = false;

	DialogueManager dialogueManager;

	// player information
	private string currentSceneName; // current position in the castle
	private PlayerController player;

	// game objects to keep track of


	// Use this for initialization
	void Start () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		currentSceneName = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		currentSceneName = SceneManager.GetActiveScene().name;
		switch(currentSceneName) {
		case "level1":
			level1 ();
			break;
		default:
			break;
		}
	}

	// scripted events for each level
	private void level1() {
		if (!playerBeginningMonologue) {
			//dialogueManager.cutSceneDialogue ();
		}
	}

	public void playDialogue(DialogueActivator character) {
		List<string> lines = new List<string> ();
		if (character.name == "Remembrance") {
			lines = new List<string> { "I am Remembrance!", "Welcome to the castle!" };
		} else if (character.name == "Entrance") {
			lines = new List<string> { "I can't leave until I get that flower ..." };
		} else {
			lines = new List<string> { "I don't know what to say ..." };
		}
		dialogueManager.displayDialogue (character.portrait.sprite, character.name, lines);
	}

	public void playIntroCutScene() {
		List<string> lines = new List<string> ();
		lines = getLines(currentSceneName);
		dialogueManager.displayDialogue (null, "", lines);
	}

	private List<string> getLines(string characterName) {
		List<string> lines = new List<string> ();
		if (characterName == "intro_cutscene") {
			TextAsset script = Resources.Load ("DialogueScripts/" + characterName) as TextAsset;
			lines = new List<string> (script.text.Split('\n'));
		}
		return lines;
	}
}
