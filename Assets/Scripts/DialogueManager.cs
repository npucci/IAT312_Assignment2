using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public PlayerController player;

    public Text dialogueScript;

    public TextAsset textFile;
    public string[] textLines;

    public int lineTracker;
    public int lastLine;

    public bool isActive;
    public bool pausePlayer;

    // Use this for initialization
    void Start()
    {

        player = FindObjectOfType<PlayerController>();

        if (textFile != null)
        {

            textLines = (textFile.text.Split('\n'));                    //Read the text lines as individual lines
        }

        if (lastLine == 0) {
            lastLine = textLines.Length - 1;                            //Reading when we hit the last line of the dialogue
        }

        if (isActive == true)
        {
            EnableDialogueBox();
        }
        else {
            DisableDialogueBox();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false) {
            return;
        }

        dialogueScript.text = textLines[lineTracker];                   //From the textfile, store them within an array

        if (Input.GetKeyDown(KeyCode.F)) {
            lineTracker += 1;                                           //Display the next line when the corresponding key is hit
        }

        if (lineTracker > lastLine) {
            DisableDialogueBox();
        }
    }

    public void EnableDialogueBox() {
        dialogueBox.SetActive(true);
        pausePlayer = true;
        isActive = true;

        if (pausePlayer == true) {
            player.enabledMove = false;
        }   
    }

    public void DisableDialogueBox() {
        dialogueBox.SetActive(false);                               //If the last line is reached, remove the dialogue box
        isActive = false;

        player.enabledMove = true;
 
    }

    public void LoadNewScript(TextAsset script) {

        if (script != null) {
            textLines = new string[1];

            textLines = (script.text.Split('\n'));
        }
    }
}
