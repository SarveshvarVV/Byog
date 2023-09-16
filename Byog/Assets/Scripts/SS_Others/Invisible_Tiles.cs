using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible_Tiles : MonoBehaviour
{
    SpriteRenderer sp;
    BoxCollider2D bc;
    private bool isVisible = false;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        HideBlock();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Assuming the player has a "Player" tag.
        {
            // Check if the player is colliding from below.
            Vector2 playerPosition = collision.transform.position;
            Vector2 blockPosition = transform.position;

            if (playerPosition.y < blockPosition.y)
            {
                if (!isVisible)
                {
                    ShowBlock();
                }
            }
        }
    }
    private void ShowBlock()
    {
        bc.isTrigger = false;
        gameObject.layer = LayerMask.NameToLayer("Ground");
        sp.enabled = true;
        isVisible = true;
    }

    private void HideBlock()
    {
        bc.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Default");
        sp.enabled = false;
        isVisible = false;
    }
}

