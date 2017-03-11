using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {
	private CanvasGroup pauseCanvas;
	private CanvasGroup gameOverCanvas;
	private CanvasGroup hudCanvas;
	private CanvasGroup dialogueBox;

	private bool pause = false;
	private bool hasDied = false;

	public Health player;

	void Awake() {
	}
		
	void Start () {
		pauseCanvas = GameObject.Find ("Pause").GetComponent<CanvasGroup> ();
		gameOverCanvas = GameObject.Find ("GameOver").GetComponent<CanvasGroup> ();
		hudCanvas = GameObject.Find ("HUD").GetComponent<CanvasGroup> ();
		dialogueBox = GameObject.Find ("DialogueBox").GetComponent<CanvasGroup> ();
		initializeCanvas ();

		player = GameObject.Find ("Player").GetComponent<Health> ();
	}

	void Update () {
		if (!hasDied && Input.GetKeyDown (KeyCode.Escape)) {
			pause = !pause;
			if (pause) {
				pauseGame ();
			} 
			else {
				resumeGame ();
			}
		}

		if (player.dead ()) {
			hasDied = true;
			gameOver ();
		}

		// debug restart
		if (Input.GetKeyDown (KeyCode.F1)) {
			//restartLevel();
		}

		// debug go to main menu
		if (Input.GetKeyDown (KeyCode.F2)) {
			goToMainMenu();
		}
	}

	private void initializeCanvas () {
		// Enable HUD Canvas
		enableCanvas(hudCanvas, true);

		// Disable Pause Canvas
		enableCanvas(pauseCanvas, false);

		// Disable Game Over Canvas
		enableCanvas(gameOverCanvas, false);

		// Enable Dialogue Box Canvas
		enableCanvas(dialogueBox, true);
	}

	private void pauseGame() {
		Time.timeScale = 0f;
		// Disable HUD Canvas
		enableCanvas(hudCanvas, false);
		// Disable dialogueBox Canvas
		enableCanvas(dialogueBox, false);
		// Enable Pause Canvas
		enableCanvas(pauseCanvas, true);
	}

	private void resumeGame() {
		Time.timeScale = 1f;
		// Disable Pause Canvas
		enableCanvas(pauseCanvas, false);
		// Enable dialogueBox Canvas
		enableCanvas(dialogueBox, true);
		// Enable HUD Canvas
		enableCanvas(hudCanvas, true);
	}

	public void gameOver() {
		// Disable Pause Canvas
		enableCanvas(pauseCanvas, false);
		// Disable dialogueBox Canvas
		enableCanvas(dialogueBox, false);
		// enable Game Over Canvas
		enableCanvas (gameOverCanvas, true);
	}

	private void enableCanvas(CanvasGroup canvas, bool enable) {
		if(enable) {
			canvas.alpha = 1f;
		}
		else {
			canvas.alpha = 0f;
		}

		canvas.interactable = enable;
		canvas.blocksRaycasts = enable;
	}

	public void goToMainMenu() {
		Application.LoadLevel (0);
	}

	public void restartLevel() {
		Application.LoadLevel (SceneManager.GetActiveScene().buildIndex);
	}
}
