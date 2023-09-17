using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Blob : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    Rigidbody2D rb;
    Transform currentPoint;
    [SerializeField] float speed;

    CircleCollider2D cc2d;

    private void Start()
    {
        cc2d = GetComponent<CircleCollider2D>();
        rb= GetComponent<Rigidbody2D>();
        currentPoint = pointB;
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB)
        {
            Flip();
            currentPoint = pointA;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA)
        {
            Flip();
            currentPoint = pointB;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cc2d != null)
        {
            if (collision.CompareTag("Player"))
            {
                //display text
                SS_GameController.playerIsDead = true;
            }
            else
            {
                SS_GameController.playerIsDead =false;
            }
        }
    }
}
