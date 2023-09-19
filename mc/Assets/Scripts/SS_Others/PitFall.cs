using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFall : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (boxCollider != null)
        {
            if (collision.CompareTag("Player"))
            {
                StartCoroutine(Pit_Fall());
            }
        }
    }

    IEnumerator Pit_Fall()
    {
        boxCollider.enabled = false;
        rb2d.gravityScale = 5f;
        gameObject.layer = LayerMask.NameToLayer("Default");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
