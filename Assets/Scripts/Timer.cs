using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer {
	private float timerAmount;
	private float countDown;
	private bool timerStarted;
	private bool stop = true;

	// default constructor
	public Timer() {}

	// overloaded constructor
	public Timer(float timerAmount) {
		this.timerAmount = timerAmount;
	}

	// Update is called once per frame
	public void updateTimer (float deltaTime) {
		if (!stop && countDown > 0) {
			countDown -= deltaTime;
			if (countDown < 0) {
				stop = true;
			}
		}
	}

	// starts timer
	public void startTimer () {
		countDown = timerAmount;
		stop = false;
	}

	public void restartTimer() {
		startTimer ();
	}

	// returns true if the timer is stopped
	public bool stopped() {
		return stop;
	}

	// resetting value of timer
	public void setTimer(float timerAmount) {
		this.timerAmount = timerAmount;
	}

	public float currentTimeRemaining() {
		return countDown;
	}
}