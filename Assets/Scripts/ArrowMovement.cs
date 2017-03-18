using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {

    private Vector2 moveX;
    private Rigidbody2D rb;
    private SpriteRenderer playersr;
    private SpriteRenderer sr;

    private bool turnLeft;
    private bool turnRight;

    public float fireDistance = 30.0f;
    public float arrowDamage = 1.0f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        playersr = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        Physics2D.IgnoreLayerCollision(8, 10, true);

        int direction = 1;

        if (playersr.flipX == true) {
            direction = -1;

            sr.flipX = true;
        }

        moveX = new Vector2(fireDistance * direction, 0);
    }
	
	// Update is called once per frame
	void Update () {
         rb.AddForce(moveX, ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name.Contains("Enemy")){

            other.gameObject.GetComponent<Health>().decreaseHp(arrowDamage);
            Destroy(gameObject);
        }
    }
}
