using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemistProjectile : MonoBehaviour {

    public GameObject ProjectilePrefabs;
    public Transform ProjectileInstantiate;
	public Alchemist chemist;

    public float fireRate;

    public Timer fireTimer;

    private bool fire = false;

	// Use this for initialization
	void Start () {
        fireTimer = new Timer(fireRate);
    }
	
	// Update is called once per frame
	void Update () {
		fire = chemist.iffire();

        fireTimer.updateTimer(Time.deltaTime);
        if (!fire && fireTimer.stopped()) {
            fire = true;
        }

        FireProjectile();
	}

    public void FireProjectile() {
        if (fire)
        {
            GameObject enemyProjectile = Instantiate(ProjectilePrefabs, ProjectileInstantiate.transform.position, ProjectileInstantiate.rotation);
            fireTimer.startTimer();
            fire = false;

        }
    }

    public bool isFiring() {
        return fire;
    }
}
