using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_Mover : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    public bool canMove = true;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if(moveInput.x < 0.01f)
        {
            anim.SetBool("Idle_right", false);
        }
        else if (moveInput.x > 0.01f)
        {
            anim.SetBool("Idle_right", true);
        }

        anim.SetFloat("Horiontal", moveInput.x);
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
        
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
        moveInput.Normalize();
        rb2d.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
    }
}
