using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour {

    private Vector2 moveX;
    private Rigidbody2D rb;

    public float fireDistance = 30.0f;
    public float proDamage = 1.0f;
    public float torque;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        moveX = new Vector2(fireDistance, 0);
    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(moveX, ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {

            other.gameObject.GetComponent<Health>().decreaseHp(proDamage);
            Destroy(gameObject);
        }
    }
}
