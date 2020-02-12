using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private Player player;
    private Transform target;
    [SerializeField] float aggroRange;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if(distanceToPlayer < aggroRange)
        {
            ChasingPlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    private void StopChasingPlayer()
    {
        rb.velocity = Vector2.zero;
    }

    private void ChasingPlayer()
    {
        if(transform.position.x < target.position.x+3)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
