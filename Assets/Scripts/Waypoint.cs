﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour {

    private int loadNextLevel;

	// Use this for initialization
	void Start () {
        loadNextLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerStay2D(Collision2D Other) {
    if (Input.GetKeyDown(KeyCode.W))
     {
        Application.LoadLevel(loadNextLevel + 1);
     } 
    }
}
