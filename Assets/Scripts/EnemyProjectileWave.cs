using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileWave : MonoBehaviour
{

    private Vector2 moveWave;
    private Vector2 moveX;
    private Rigidbody2D rb;
    private float playerPos;
    private SpriteRenderer sr;

    public float frequency = 20.0f;
    public float magnitude = 0.5f;
    public float fireDistance = 30.0f;
    public float proDamage = 1.0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        playerPos = GameObject.Find("Player").transform.position.x;

        int direction = 1;

        if (transform.position.x > playerPos)
        {
            direction = -1;

            sr.flipX = true;
        }

        moveWave = new Vector2(fireDistance * direction, fireDistance * direction * Mathf.Sin(Time.time * frequency) * magnitude);

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(moveWave, ForceMode2D.Impulse);
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