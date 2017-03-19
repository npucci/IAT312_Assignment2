using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist : MonoBehaviour {
	
	public float Attack_Interval = 0.5f;
	private Timer AttackTimer;
	public bool isattacking;
	private Animator anim;

	public GameObject FireballPrefabs;
	public Transform FireballInstantiatePoint;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		isattacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isattacking) {
			anim.CrossFade ("attack", 0f);
			AttackTimer.startTimer ();
		} 
		else {
			anim.CrossFade ("idle", 0f);
		}
	}

	public bool iffire(){
		return isattacking;
	}
}
