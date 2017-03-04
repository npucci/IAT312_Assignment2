using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour {

    public TextAsset textFile;

    public int startLine;
    public int endLine;

    public bool playerActivateButton;
    private bool waitForPlayer;

    public DialogueManager dialogueAttach;

	// Use this for initialization
	void Start () {
        dialogueAttach = FindObjectOfType<DialogueManager>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (waitForPlayer == true && Input.GetKeyDown(KeyCode.E)) {

            dialogueAttach.LoadNewScript(textFile);
            dialogueAttach.lineTracker = startLine;
            dialogueAttach.lastLine = endLine;

            dialogueAttach.EnableDialogueBox();
        }
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {

            if (playerActivateButton == true) {
                waitForPlayer = true;
                return;
            }

            dialogueAttach.LoadNewScript(textFile);
            dialogueAttach.lineTracker = startLine;
            dialogueAttach.lastLine = endLine;

            dialogueAttach.EnableDialogueBox();

        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player") {
            waitForPlayer = false;
        }
   }
}
