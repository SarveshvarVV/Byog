using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    CapsuleCollider2D collider2d;
    Animator animator;
    GameObject player;
    CollectableCounter cc;

    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        cc = player.GetComponent<CollectableCounter>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collider2d != null)
        {
            if (collision.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    cc.AddCount();
                    StartCoroutine(ShrinkAndDestroy());
                }
            }
        }
    }

    IEnumerator ShrinkAndDestroy()
    {
        animator.SetTrigger("Shrink");
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);
    }
}
