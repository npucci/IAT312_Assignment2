using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvasion : MonoBehaviour {

    public float dashDistance = 30f;
    public float dashFrames = 0.5f;

    public Timer dashTimer;

    private bool dashing = false;
    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        dashTimer = new Timer(dashFrames);

        player = GameObject.Find("Player");
        sr.flipX = true;
    }

    // Update is called once per frame
    void Update() {

        dashTimer.updateTimer(Time.deltaTime);

        Vector2 moveX = new Vector2(dashDistance, 0);

        if (dashTimer.stopped() && Input.GetMouseButtonDown(1))
        {
            dashing = true;
        }
        else {
            dashing = false;
        }

        if (dashing == true && Input.GetMouseButtonDown(1))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            if (sr.flipX == true)
            {
                rb.AddForce(moveX * 50, ForceMode2D.Impulse);
                dashTimer.startTimer();
            }
            else if (sr.flipX == false) {
                rb.AddForce(-moveX * 50, ForceMode2D.Impulse);
                dashTimer.startTimer();

            }

        }
        else if (Input.GetMouseButtonUp(1) || dashTimer.stopped()) {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            dashing = false;
        }
	}
}
