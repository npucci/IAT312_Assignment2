using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    private SpriteRenderer sr;
    private float playerPos;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        playerPos = GameObject.Find("Player").transform.position.x;

        if (transform.position.x > playerPos)
        {
            sr.flipX = true;
        }
        else {
            sr.flipX = false;
        }

    }
}
