using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Flying_Blob : MonoBehaviour
{
    CircleCollider2D circleCollider;
    public bool touched;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Transform target;

    Flying_Blob_Mover fbm;
    // Start is called before the first frame update
    void Start()
    {
        fbm = GetComponentInChildren<Flying_Blob_Mover>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (circleCollider != null) 
        {
            if (collision.CompareTag("Player"))
            {
                touched = true;
            }
            else
            {
                touched = false;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (fbm.startMove)
        {

            StartCoroutine(FlyBlobMovement());
        }
    }

    IEnumerator FlyBlobMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed);
        yield return new WaitForSeconds(2f);  
        Destroy(gameObject);
    }
}
