using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public GameObject ArrowPrefabs;
    public Transform ArrowInstantiatePoint;

    public Timer fireTimer;

    public float fireRate;

    public int maxArrow;
    public int numArrow;

    private bool fire = false;

    // Use this for initialization
    void Start () {
        numArrow = maxArrow;

        fireTimer = new Timer(fireRate);
    }
	
	// Update is called once per frame
	void Update () {

        fireTimer.updateTimer(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q) && !fire && numArrow > 0)
        {
            fire = true;
            fireTimer.startTimer();
        }

        if (Input.GetKeyUp(KeyCode.Q) || fireTimer.stopped() || numArrow == 0) {
            fire = false;
        }

        InstantiateArrows();
    }

    public void InstantiateArrows() {
        if (fire == true)
        {
            GameObject Arrow;
            Arrow = Instantiate(ArrowPrefabs, ArrowInstantiatePoint.transform.position, ArrowInstantiatePoint.rotation) as GameObject;

            numArrow -= 1;
        } else if (fireTimer.stopped())
        {
            fire = false;
        }
    }

    public bool isFiring()
    {
        return fire;
    }
}
