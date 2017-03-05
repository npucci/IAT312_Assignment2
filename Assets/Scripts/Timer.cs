using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	private float timerAmount;
	private float countDown;
	private bool timerStarted;
	private bool stop = true;
	
	// Update is called once per frame
	void Update () {
		if (!stop && countDown > 0) {
			Debug.Log (countDown);
			countDown -= Time.deltaTime;
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

	// returns true if the timer is stopped
	public bool stopped() {
		return stop;
	}

	// resetting value of timer
	public void setTimer(float amount) {
		timerAmount = amount;
	}
}