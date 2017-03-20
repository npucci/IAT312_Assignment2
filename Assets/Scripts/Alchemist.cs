using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alchemist : MonoBehaviour {
	
	public bool isattacking,wait;
	private Animator anim;
	private Health healthManager;
	public GameObject background_before;

	public GameObject FlowerPrefabs;
	public Transform FlowerInstantiate;
	public GameObject targetSliderOject;

	public GameObject FireballPrefabs;
	public Transform FireballInstantiatePoint;
	public float interval;
	public float fireRate;
	

	public Timer PauseTimer;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		healthManager = GetComponent<Health> ();
		isattacking = false;
		wait = true;
		PauseTimer.startTimer();
		PauseTimer = new Timer(interval);
	}
	
	// Update is called once per frame
	void Update () {
		PauseTimer.updateTimer (Time.deltaTime);
			
		if(wait && PauseTimer.stopped ()){
				isattacking = true;
				wait = false; 
			}

		if (isattacking) {
			anim.CrossFade ("attack", 0f);

		} 
		else {
			anim.CrossFade ("idle", 0f);
		}
		if(healthManager.dead()) {
			Instantiate(FlowerPrefabs, FlowerInstantiate.transform.position, FlowerInstantiate.rotation);
			Destroy (background_before);
			targetSliderOject.SetActive (false);
			Destroy(gameObject);
		}
	}
	void FixedUpdate() {
		if (wait == false) {
			PauseTimer.startTimer();
			isattacking = false;
			wait = true;
		}
	}

	public bool iffire(){
		return isattacking;
	}
}
