using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

	public void Menu(){
		// must add a game save feature here, before destroying the objects
		Destroy (GameObject.Find("Player"));
		Destroy (GameObject.Find("Narrative Engine"));
		SceneManager.LoadScene (0);//change the variable according to your build settings^^
	}

	public void Intro (){
		SceneManager.LoadScene (1);//change the variable according to your build settings^^
	}

	public void LevelOne(){
		SceneManager.LoadScene (2);//change the variable according to your build settings^^
	}

	public void LevelTwo(){
		SceneManager.LoadScene (3);//change the variable according to your build settings^^
	}

	public void LevelThree(){
		SceneManager.LoadScene (4);//change the variable according to your build settings^^
	}
}



