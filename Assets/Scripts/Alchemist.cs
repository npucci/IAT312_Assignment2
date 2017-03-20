using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alchemist : MonoBehaviour {
	
	public bool isattacking,wait;
	private Animator anim;
	private Health healthManager;
	public GameObject background_before;

	public float speed,initialx;
	public GameObject FlowerPrefabs;
	public Transform FlowerInstantiate;
	public GameObject targetSliderOject;

	public GameObject FireballPrefabs;
	public Transform FireballInstantiatePoint;
	public float pause_time,attack_time,light_time;
	public PlayerController player;
	private Vector3 pos;
	private SpriteRenderer sr;

	

	public Timer PauseTimer,AttackTimer,LightTimer;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		healthManager = GetComponent<Health> ();
		isattacking = false;
		wait = true;
		PauseTimer = new Timer(pause_time);
		AttackTimer = new Timer(attack_time);
		LightTimer = new Timer(light_time);
		PauseTimer.startTimer();
		sr = GetComponent<SpriteRenderer> ();
		initialx = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		pos = this.transform.position;
		PauseTimer.updateTimer (Time.deltaTime);
		AttackTimer.updateTimer (Time.deltaTime);
		LightTimer.updateTimer (Time.deltaTime);


		if (player.getposition ().x < pos.x) {
			sr.flipX = false;
			if (player.getposition ().y < 6 && pos.x>(initialx-12) && pos.x<=initialx) {
				transform.Translate (Vector2.left * speed / 10);
			}
		}
		if (player.getposition ().x > pos.x) {
			sr.flipX = true;
			if (player.getposition ().y < 6 && pos.x>(initialx-12) && pos.x<=initialx) {
				transform.Translate (Vector2.right * speed / 10);
			}
		}


		//For the pause and the light 
		if(wait && PauseTimer.stopped ()){
				isattacking = true;
				wait = false; 
				AttackTimer.startTimer();
				anim.CrossFade ("attack", 0f);
				GameObject.Find ("Light").GetComponent<Light> ().intensity=1.3f;
			}
		if (!wait && AttackTimer.stopped ()) {
			isattacking = false;
			wait = true; 
			PauseTimer.startTimer();
			anim.CrossFade ("Idle", 0f);
			LightTimer.startTimer();
		}
		if (wait && LightTimer.stopped ()) {
			GameObject.Find ("Light").GetComponent<Light> ().intensity=3.0f;
		}


		if(healthManager.dead()) {
			Instantiate(FlowerPrefabs, FlowerInstantiate.transform.position, FlowerInstantiate.rotation);
			Destroy (background_before);
			targetSliderOject.SetActive (false);
			Destroy(gameObject);
		}
	}

	public bool iffire(){
		return isattacking;
	}
}
