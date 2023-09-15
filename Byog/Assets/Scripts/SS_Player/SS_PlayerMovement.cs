using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpVelocity;
    [SerializeField] Vector2 velocity;
    bool walk, walk_left, walk_right, jump;
    [SerializeField] float gravity;
    [SerializeField] LayerMask wallMask;
    [SerializeField] LayerMask floorMask;

    [SerializeField] enum PlayerState
    {
        idle,
        jumping,
        walking
    }

    private PlayerState playerState = PlayerState.idle;

    bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        Fall();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInput();
        UpdatePlayerMotion();
    }

    private void UpdatePlayerMotion()
    {
        Vector3 pos = transform.localPosition;
        Vector3 scale = transform.localScale;
        if (walk)
        {
            if(walk_left)
            {
                pos.x -= velocity.x * Time.deltaTime;
                scale.x = -1;
            }
            if (walk_right)
            {
                pos.x += velocity.x * Time.deltaTime;
                scale.x = 1;
            }
            pos = CheckWallRays(pos, scale.x);
        }

        if(jump && playerState != PlayerState.jumping)
        {
            playerState = PlayerState.jumping;
            velocity = new Vector2(velocity.x, jumpVelocity);
        }
        if(playerState == PlayerState.jumping)
        {
            pos.y += velocity.y * Time.deltaTime;
            velocity.y -= gravity * Time.deltaTime;
        }

        if(velocity.y <=0)
        {
            pos = CheckFloorRays(pos);
        }

        transform.localPosition = pos;
        transform.localScale = scale;
    }

    private void CheckPlayerInput()
    {
        bool input_left = Input.GetKey(KeyCode.A);
        bool input_right = Input.GetKey(KeyCode.D);
        bool input_space = Input.GetKey(KeyCode.Space);

        walk = input_left || input_right;
        walk_left = input_left && !input_right;
        walk_right = input_right && !input_left;
        jump = input_space;
    }

    Vector3 CheckWallRays(Vector3 pos, float direction)
    {
        Vector2 originTop = new Vector2(pos.x + direction * 0.4f, pos.y + 1f - 0.2f);
        Vector2 originMiddle = new Vector2(pos.x + direction * 0.4f, pos.y);
        Vector2 originBottom = new Vector2(pos.x + direction * 0.4f, pos.y - 1f + 0.2f);

        RaycastHit2D wallTop = Physics2D.Raycast(originTop, new Vector2(direction, 0), velocity.x * Time.deltaTime, wallMask);
        RaycastHit2D wallMiddle = Physics2D.Raycast(originMiddle, new Vector2(direction, 0), velocity.x * Time.deltaTime, wallMask);
        RaycastHit2D wallBottom = Physics2D.Raycast(originBottom, new Vector2(direction, 0), velocity.x * Time.deltaTime, wallMask);

        if(wallTop.collider != null || wallMiddle.collider != null || wallBottom.collider != null)
        {
            pos.x -= velocity.x * Time.deltaTime * direction;
        }
        return pos;
    }

    Vector3 CheckFloorRays(Vector3 pos)
    {
        Vector2 originLeft = new Vector2(pos.x - 0.5f + 0.2f,pos.y - 1f);
        Vector2 originMiddle = new Vector2(pos.x, pos.y - 1f);
        Vector2 originRight = new Vector2(pos.x + 0.5f - 0.2f, pos.y - 1f);

        RaycastHit2D floorLeft = Physics2D.Raycast (originLeft, Vector2.down, velocity.y * Time.deltaTime, floorMask);
        RaycastHit2D floorMiddle = Physics2D.Raycast(originMiddle, Vector2.down, velocity.y * Time.deltaTime, floorMask);
        RaycastHit2D floorRight = Physics2D.Raycast(originRight, Vector2.down, velocity.y * Time.deltaTime, floorMask);

        if(floorLeft.collider !=null || floorMiddle.collider != null || floorRight.collider != null)
        {
            RaycastHit2D hitray = floorRight;
            if (floorLeft)
            {
                hitray = floorLeft;
            }
            else if (floorMiddle)
            {
                hitray = floorMiddle;
            }
            else if (floorRight)
            {
                hitray = floorRight;
            }
            playerState = PlayerState.idle;
            grounded = true;
            velocity.y = 0f;   
            pos.y = hitray.collider.bounds.center.y + hitray.collider.bounds.size.y / 2 +1;
        }
        else
        {
            if(playerState == PlayerState.jumping)
            {
                Fall();
            }
        }
        return pos;
    }

    void Fall()
    {
        velocity.y = 0;
        playerState = PlayerState.jumping;
        grounded = false;
    }

}