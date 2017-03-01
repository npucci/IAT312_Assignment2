using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	private float timerAmount;
	private float countDown;
	private bool timerStarted;

	/*
	// empty constructor
	public Timer () {
		timerAmount = 0f;
		countDown = 0f;
		timerStarted = false;
	}

	// overloaded constructor
	public Timer (float amount) {
		timerAmount = amount;
		countDown = 0f;
		timerStarted = false;
	}
	*/
	
	// Update is called once per frame
	void Update () {
		if (countDown > 0) {
			countDown -= Time.deltaTime;
		}
	}

	// starts timer
	public void startTimer () {
		countDown = timerAmount;
	}

	// returns true if the timer is stopped
	public bool stopped() {
		return countDown <= 0;
	}

	// resetting value of timer
	public void setTimer(float amount) {
		timerAmount = amount;
	}
}