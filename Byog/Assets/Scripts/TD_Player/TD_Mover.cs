using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_Mover : MonoBehaviour
{
    Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    Animator anim;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    public bool canMove = true;
    bool flipLeft = true;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (moveInput.x != 0f)
        {
            // Player is moving, update the last movement direction
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                // Horizontal movement is greater, so use left or right
                flipLeft = (moveInput.x < 0f) ? true : false;
            }
        }

        if(flipLeft)
        {
            spriteRenderer.flipX = false;
        }
        else if (!flipLeft)
        {
            spriteRenderer.flipX = true;
        }

        if(moveInput != Vector2.zero) 
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
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
        moveInput.Normalize();
        rb2d.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
    }
}
