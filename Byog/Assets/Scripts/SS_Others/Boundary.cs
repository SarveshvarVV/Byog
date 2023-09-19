using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (boxCollider != null)
        {
            if (collision.CompareTag("Player"))
            {
                SS_GameController.playerIsDead = true;
            }
            else
            {
                SS_GameController.playerIsDead = false;
            }
        }
    }
}
