using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class DialogueManager : MonoBehaviour {
	// child component fields
	private Image background;
	private Image portrait;
	private GameObject dialogueBox;
	private Text dialogueText;
	private Image nameBackground;
	private Text nameText;

	// other fields
	private int lineTracker;
    private PlayerController player;
	private List<string> textLines;

    // Use this for initialization
    void Start()
    {
		// get components
		background = transform.GetChild (0).gameObject.GetComponent<Image>();
		portrait = transform.GetChild (1).gameObject.GetComponent<Image>();
		dialogueBox = transform.GetChild (2).gameObject;
		dialogueText = dialogueBox.transform.GetChild (0).gameObject.GetComponent<Text>();
		nameBackground = transform.GetChild (3).gameObject.GetComponent<Image>();
		nameText = transform.GetChild (4).gameObject.GetComponent<Text> ();

        player = FindObjectOfType<PlayerController>();
		textLines = new List<string> ();
		lineTracker = -1;
		enableAll (false);
    }

    // Update is called once per frame
    void Update()
    {
		// if player is not destroyed on load, this script won't be able to find it for a short interval, so it must check a bit later
		// also, the other find method will not work in this case, so here is an alternative method that must be used
		if (player == null) {
			player = (PlayerController)FindObjectOfType (typeof(PlayerController));
		}

		if (lineTracker != -1 && Input.GetKeyDown(KeyCode.F)) {
            lineTracker += 1; //Display the next line when the corresponding key is hit
        }
	
		if (lineTracker >= textLines.Count) {
			if (EditorSceneManager.GetActiveScene ().name != "intro_cutscene") {
				enableAll (false);
			}
			player.enablePlayerMovement (true);
			lineTracker = -1;
		} else if(lineTracker > -1 && lineTracker < textLines.Count){
			enableAll (true);
			player.enablePlayerMovement (false);
			dialogueText.text = textLines[lineTracker];
		}
    }

	private void enableDialogueBox(bool enable) {
        dialogueBox.SetActive(enable);
    }

	private void enableBackground(bool enable) {
		background.enabled = enable;                               //If the last line is reached, remove the dialogue box
	}

	private void enablePortrait(bool enable) {
		portrait.enabled = enable;                               //If the last line is reached, remove the dialogue box
	}

	private void enableNameBackground(bool enable) {
		nameBackground.enabled = enable;                               //If the last line is reached, remove the dialogue box
	}

	private void enableNameText(bool enable) {
		nameText.enabled = enable;                               //If the last line is reached, remove the dialogue box
	}

	private void enableAll(bool enable) {
		enableBackground (enable);
		enableDialogueBox(enable);
		enablePortrait (enable);
		enableNameBackground (enable);
		enableNameText (enable);
	}

	public void displayDialogue(Sprite characterPortrait, string characterName, List<string> lines) {
		if (characterPortrait != null) {
			portrait.sprite = characterPortrait;
		}
		nameText.text = characterName;
		textLines = lines;
		lineTracker = 0;
		enableAll (true);
	}
}
