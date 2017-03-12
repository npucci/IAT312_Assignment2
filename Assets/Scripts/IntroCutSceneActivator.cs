using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutSceneActivator : MonoBehaviour {
	private NarrativeEngine narrativeEngine;
	private bool played = false;

	// Use this for initialization
	void Start () {
		narrativeEngine = FindObjectOfType<NarrativeEngine>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!played) {
			narrativeEngine.playIntroCutScene ();
			played = true;
		}
	}
}
