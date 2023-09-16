using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGOAT_System : MonoBehaviour, Interactables
{
    [SerializeField] float sGOATtraverse_Speed = 2f;
    [SerializeField] Transform sGOATtraverse_Player;
    [SerializeField] Transform sGOATtraverse_Aside;
    [SerializeField] GameObject sGOAT_Spawn;
    TD_SGOAT_Spawn system;
    public bool sGOAT_InterationComplete = false;

    [SerializeField] CVC_Interactions vc_interaction;

    // Start is called before the first frame update
    void Start()
    {
        system = sGOAT_Spawn.GetComponent<TD_SGOAT_Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (system.sGOAT_StartInteract)
        {
            vc_interaction.followSGOAT = true;
            StartCoroutine(SGOAT_Inital());
            
        }
    }

    IEnumerator SGOAT_Inital()
    {
        transform.position = Vector2.MoveTowards(transform.position, sGOATtraverse_Player.position, sGOATtraverse_Speed);
        yield return new WaitForSeconds(4f);
        vc_interaction.followSGOAT = false;
        //dialog
        //once dialog is over call MoveAside();
        system.sGOAT_StartInteract = false;
        sGOAT_InterationComplete = true;
    }
    void MoveAside()
    {
        transform.position = Vector2.MoveTowards(transform.position, sGOATtraverse_Aside.position, sGOATtraverse_Speed);
    }
    void Interactables.Interact()
    {
        Debug.Log("awedawfd");
    }
}
