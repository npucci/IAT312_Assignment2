﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvasion : MonoBehaviour {

    public float dashDistance = 30f;
    public float dashFrames = 0.5f;

    public Timer dashTimer;

    private bool dashing = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
	private PlayerController pc;
	private Animator anim;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
		pc = GetComponent<PlayerController> ();
		anim = GetComponent<Animator> ();
        dashTimer = new Timer(dashFrames);
    }

    // Update is called once per frame
    void Update() {

        dashTimer.updateTimer(Time.deltaTime);

        Vector2 moveX = new Vector2(dashDistance, 0);

		if (dashTimer.stopped()) {
			if (dashing) {
				sr.sortingOrder += 2;
			}
			dashing = false;
		}
		
		if(pc.isPlayerMovementEnabled() && !dashing && Input.GetMouseButtonDown(1)) {
            dashing = true;
			dashTimer.startTimer();
			sr.sortingOrder -= 2;
        }

		if (pc.isPlayerMovementEnabled() && dashing == true) {
            Physics2D.IgnoreLayerCollision(8, 9, true);
			if (!dashTimer.stopped() && !sr.flipX)
            {
                rb.AddForce(moveX * 50, ForceMode2D.Impulse);
            }
			else if (!dashTimer.stopped() && sr.flipX) {
                rb.AddForce(-moveX * 50, ForceMode2D.Impulse);
            }

        }
		else if (dashTimer.stopped()) {
			if (dashing) {
				sr.sortingOrder += 2;
			}
            Physics2D.IgnoreLayerCollision(8, 9, false);
            dashing = false;
        }
	}

	public bool isDashing() {
		return dashing;
	}
}
