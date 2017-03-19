using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist : MonoBehaviour {
	
	public float Attack_Interval = 0.5f;
	private Timer AttackTimer;
	private SpriteRenderer sr;
	public bool isattacking;
	private Animator anim;
	private bool fire = false;

	public GameObject FireballPrefabs;
	public Transform FireballInstantiatePoint;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		AttackTimer = new Timer (Attack_Interval);
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isattacking) {
			anim.CrossFade ("attack", 0f);
			fire = true;
			AttackTimer.startTimer ();
		} 
		else {
			fire = false;
		}
		InstantiateFireballs();
		
	}

	public void InstantiateFireballs() {
		if (fire == true)
		{
			GameObject Arrow;
			Arrow = Instantiate(FireballPrefabs, FireballInstantiatePoint.transform.position, FireballInstantiatePoint.rotation) as GameObject;

		} 
		else if (AttackTimer.stopped())
		{
			fire = false;
		}
	}
}
