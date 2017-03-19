using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HP_Alchemist : MonoBehaviour {

	private Health Health;
	public Sprite[] HPState;
	public float scalex,index; 
	public Slider targetSliderOject; 

	float getratio(){
		return Health.getHealth () / Health.getMaxHealth ();
	}
	// Use this for initialization
	void Start () {
		Health = GameObject.Find ("Alchemist_Enemy").GetComponent<Health> ();
	}


	// Update is called once per frame
	void Update () {
		targetSliderOject.value= getratio (); 


	}
	void FixedUpdate() {
	}
}

