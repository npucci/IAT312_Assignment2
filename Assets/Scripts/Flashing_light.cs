using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing_light : MonoBehaviour {
	private bool isshine;
	public float wait_time;
	public float upper_range,lower_range;

	private IEnumerator interval(){
		yield return new WaitForSeconds(wait_time);
		isshine = true ;
	}
	// Use this for initialization
	void Start () {
		isshine = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isshine) {
			if (transform.GetComponent<Light> ().range < upper_range) {
				transform.GetComponent<Light> ().range = transform.GetComponent<Light> ().range + 0.1f;
			} else {
				isshine = false;
				StartCoroutine (interval ());
			}
		} else {
			if (transform.GetComponent<Light> ().range > lower_range) {
				transform.GetComponent<Light> ().range = transform.GetComponent<Light> ().range - 0.1f;
			}

		}
	}
}
