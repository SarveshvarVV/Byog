using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_Mover : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    public bool canMove = true;
    [SerializeField] GameObject sGOAT;
    SGOAT_System system;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        system = sGOAT.GetComponent<SGOAT_System>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnSGOATInteraction();
    }

    private void CheckOnSGOATInteraction()
    {
        if (system.sGOAT_InterationComplete)
        {
            canMove = true;
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Movement();
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb2d.velocity = moveInput * moveSpeed * Time.deltaTime;
    }
}
