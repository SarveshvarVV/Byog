using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Blob_Mover : MonoBehaviour
{
    BoxCollider2D boxCollider;
    public bool startMove = false;

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
                boxCollider.enabled = false;
                startMove = true;
            }
            else{
                startMove = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
