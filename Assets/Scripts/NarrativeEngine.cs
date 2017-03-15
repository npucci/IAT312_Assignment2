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

	// DialogueManager reference
	private DialogueManager dialogueManager;

	// cutscene flags
	private bool introCutScene = false;

	// remembrance
	private bool remembranceIntro = false;

	// player information
	private string currentSceneName; // current position in the castle
	private PlayerController player;

	// game objects to keep track of

	void Awake() {
		if (instance == null) {
			instance = this;
		}

		// check for if there is a multiple or pre-existing player object in a scene,
		// and destroys it, so that only the very first instantiation exists
		else if (instance != this) {
			Destroy (gameObject);
		}

		// tells Unity not to destroy this object
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		currentSceneName = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		} 

		if (dialogueManager == null) {
			dialogueManager = FindObjectOfType<DialogueManager> ();
		}

		currentSceneName = SceneManager.GetActiveScene().name;
		switch(currentSceneName) {
		case "intro_cutscene":
			if (!introCutScene) {
				introCutScene = true;
				playCutScene ("player", "[intro]");
			}
			break;
		case "level1":
			level1 ();
			break;
		default:
			break;
		}
	}

	// scripted events for level 1 scene
	private void level1() {
		if (!enteredLv1) {
			enteredLv1 = true;
			dialogueManager.reset();
			if (!playerBeginningMonologue) {
				playCutScene ("player", "[beginning_monologue]");
			}
		}
	}

	private void playCutScene(string characterName, string lineTag) {
		List<string> lines = new List<string> ();
		if (characterName == "player") {
			lines = getLines (characterName, lineTag);
			dialogueManager.displayDialogue (player.portrait, player.playerName, lines);
		}
	}

	public void playDialogue(Sprite portrait, string name) {
		List<string> lines = new List<string> ();
		if (name == "Remembrance") {
			lines = remembranceDialogue ();
		} else if (name == "Entrance") {
			lines = getLines (player.playerName, name.ToLower());
		} else {
			lines = new List<string> { "I don't know what to say ..." };
		}

		if (dialogueManager == null) {
			dialogueManager = FindObjectOfType<DialogueManager> ();
		}
		dialogueManager.displayDialogue (portrait, name, lines);
	}

	private List<string> remembranceDialogue() {
		if (!remembranceIntro) {
			remembranceIntro = true;
			return new List<string> { "I am Remembrance!", "Welcome to the castle!" };	
		} else {
			return new List<string> { "Hey, get lost kid, meow!" };
		}
	}

	private void playIntroCutScene() {
		List<string> lines = new List<string> ();
		lines = getLines(currentSceneName, "");
		dialogueManager.displayDialogue (null, "", lines);
	}

	private List<string> getLines(string characterName, string lineTag) {
		TextAsset script;
		List<string> lines = new List<string> ();
		script = Resources.Load ("DialogueScripts/" + characterName) as TextAsset;
		if (script != null) {
			List<string> allLines = new List<string> (script.text.Split ('\n'));
			System.Predicate<string> p = new System.Predicate<string> (s => s.Contains(lineTag)); // lambda
			int start = allLines.FindIndex(p);
			int end = allLines.FindLastIndex(p);

			for (int i = start + 1; i < end; i++) {
				lines.Add (allLines[i]);
			}
		}
		return lines;
	}
}
