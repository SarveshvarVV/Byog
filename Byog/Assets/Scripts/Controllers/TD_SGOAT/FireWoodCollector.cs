using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWoodCollector : MonoBehaviour, Interactables
{
    BoxCollider2D boxCollider;


    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (boxCollider != null) 
        {
            if (collision.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    boxCollider.enabled = false;
                    Interact();
                }
            }
        }
    }
    public void Interact()
    {
        //dialog
    }
}
