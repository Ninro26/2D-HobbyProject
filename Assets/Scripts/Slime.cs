using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public Transform player;
    public float detectRange = 10;
    public bool inRange = false;
    public float moveSpeed = 2f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        detectRange *= detectRange;
    }

    void Update()
    {

        float distsqr = (player.position - transform.position).sqrMagnitude;

        if (distsqr <= detectRange)
        {
            inRange = true;

            Vector2 velocity = (player.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = velocity;
        }
    }
}