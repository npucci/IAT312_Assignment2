using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	public GameObject mechanism;
	public bool targetSwitch = false;
	public bool switchOn = false;
	private SpriteRenderer sr,platform;
	private Animator anim;


	void Start() {
		turnOffMechanisms ();
		sr = GetComponent<SpriteRenderer> ();
		platform = mechanism.GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	void Update() {
		if(switchOn) turnOnMechanisms ();
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (!targetSwitch && !switchOn && coll.transform.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E)) {
			switchOn = true;
			anim.CrossFade ("turnon", 0f);
			platform.color = new Color (255f, 0f, 0f, 255f);
			Debug.Log ("Switch Pressed");
			turnOnMechanisms ();
		}

		if(targetSwitch && coll.gameObject.name.Contains("Arrow")) {
			switchOn = true;
			sr.color = new Color (255f, 0f, 0f, 255f);
			platform.color = new Color (255f, 0f, 0f, 255f);
			Debug.Log ("Switch Target Hit");
			turnOnMechanisms ();
		}
	}

	void OnTriggerStay2D (Collider2D coll) {
		Debug.Log ("Switch Target Hit");
		if (!targetSwitch && !switchOn && coll.transform.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E)) {
			switchOn = true;
			Debug.Log ("Switch Pressed");
			turnOnMechanisms ();
		}

		if(targetSwitch && coll.gameObject.name.Contains("Arrow")) {
			switchOn = true;
			Debug.Log ("Switch Target Hit");
			turnOnMechanisms ();
		}
	}

	private void turnOnMechanisms () {
		if (mechanism.GetComponent<Horizon_plateform> () != null) {
			mechanism.GetComponent<Horizon_plateform> ().startMovement ();
		} 
		if (mechanism.GetComponent<Vertical_platfrom> () != null) {
			mechanism.GetComponent<Vertical_platfrom> ().startMovement ();
		}
		if (mechanism.GetComponent<RotatePlatform> () != null) {
			mechanism.GetComponent<RotatePlatform> ().startMovement ();
		}
	}

	private void turnOffMechanisms () {
		if (mechanism.GetComponent<Horizon_plateform> () != null) {
			mechanism.GetComponent<Horizon_plateform> ().stopMovement ();
		} 
		if (mechanism.GetComponent<Vertical_platfrom> () != null) {
			mechanism.GetComponent<Vertical_platfrom> ().stopMovement ();
		}
		if (mechanism.GetComponent<RotatePlatform> () != null) {
			mechanism.GetComponent<RotatePlatform> ().stopMovement ();
		}
	}
}
