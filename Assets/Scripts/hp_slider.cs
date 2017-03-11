using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class hp_slider : MonoBehaviour {
	
	private Health playerHealth;
	private int healthIndex = 4; // 4 == full, 0 == empty
	public Sprite[] HPState;
	public float scalex,index; 
	public Slider targetSliderOject; 

	float getratio(){
		return playerHealth.getHealth () / playerHealth.getMaxHealth ();
	}
	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("Player").GetComponent<Health> ();
	}


	// Update is called once per frame
	void Update () {
		targetSliderOject.value= getratio (); 


	}
	void FixedUpdate() {
	}
}
