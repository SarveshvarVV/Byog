using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TD_SGOAT_Spawn : MonoBehaviour
{

    BoxCollider2D sGOATspawncoll;
    [SerializeField] GameObject sGOAT;
    SGOAT_System system;
    GameObject player;
    TD_Mover playerMover;
    public bool sGOAT_StartInteract = false;

    void Start()
    {
        sGOATspawncoll = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        system = sGOAT.GetComponent<SGOAT_System>();
        playerMover = player.GetComponent<TD_Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (system.sGOAT_InterationComplete)
        {
            playerMover.canMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sGOATspawncoll != null)
        {
            if (collision.CompareTag("Player"))
            {
                sGOATspawncoll.enabled = false;
                player.GetComponent<TD_Mover>().canMove = false;
                sGOAT.SetActive(true);
                sGOAT_StartInteract = true;
            }
        }
    }
}
