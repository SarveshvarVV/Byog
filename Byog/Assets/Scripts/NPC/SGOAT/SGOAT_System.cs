using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SGOAT_System : MonoBehaviour, Interactables
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField] float sGOATtraverse_Speed = 2f;
    [SerializeField] Transform sGOATtraverse_Player;
    [SerializeField] Transform sGOATtraverse_Aside;
    [SerializeField] GameObject sGOAT_Spawn;
    TD_SGOAT_Spawn system;
    public bool sGOAT_InterationComplete = false;

    [SerializeField] bool canPoof = false;
    bool flipx = false;

    [SerializeField] CVC_Interactions vc_interaction;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();  
        sr = GetComponent<SpriteRenderer>();
        system = sGOAT_Spawn.GetComponent<TD_SGOAT_Spawn>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (system.sGOAT_StartInteract)
        {
            vc_interaction.followSGOAT = true;
            StartCoroutine(SGOAT_Inital());
            
        }

        if (canPoof)
        {
            StartCoroutine(Poof());
        }
        if (flipx)
        {
            sr.flipX = false;
        }
        if (!flipx)
        {
            sr.flipX = true;
        }
    }

    IEnumerator Poof()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.12f);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    IEnumerator SGOAT_Inital()
    {
        transform.position = Vector2.MoveTowards(transform.position, sGOATtraverse_Player.position, sGOATtraverse_Speed);
        yield return new WaitForSeconds(4f);
        vc_interaction.followSGOAT = false;
        //dialog
        yield return new WaitForSeconds(5f);
        flipx = true;
        transform.position = Vector2.MoveTowards(transform.position, sGOATtraverse_Aside.position, sGOATtraverse_Speed);
        system.sGOAT_StartInteract = false;
        sGOAT_InterationComplete = true;
    }


    void Interactables.Interact()
    {
        //dialog
    }
}
