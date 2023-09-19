using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SGOAT_System : MonoBehaviour, Interactables
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    BoxCollider2D boxcollider;

    [SerializeField] GameObject nextScene;
    [SerializeField] GameObject campFire;
    [SerializeField] Transform campLocation;

    [SerializeField] float sGOATtraverse_Speed = 2f;
    [SerializeField] Transform sGOATtraverse_Player;
    [SerializeField] Transform sGOATtraverse_Aside;
    [SerializeField] GameObject sGOAT_Spawn;
    TD_SGOAT_Spawn system;
    public bool sGOAT_InterationComplete = false;

    [SerializeField] GameObject dialogbox;

    [SerializeField] bool canPoof = false, moveToPlayer,moveFromPlayer,moveToCamp;
    bool flipx = false;

    public CVC_Interactions vc_interaction;


    public static bool interaction0 = true, interaction1 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();  
        boxcollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        system = sGOAT_Spawn.GetComponent<TD_SGOAT_Spawn>();
        anim = GetComponent<Animator>();
        sGOAT_InterationComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, sGOATtraverse_Player.position, sGOATtraverse_Speed);
        }
        if (moveFromPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, sGOATtraverse_Aside.position, sGOATtraverse_Speed);
        }
        if (moveToCamp)
        {
            transform.position = Vector2.MoveTowards(transform.position, campLocation.position, sGOATtraverse_Speed);
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
        nextScene.SetActive(true);
        dialogbox.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator SGOAT_Inital()
    {
        StartCoroutine(GoatComingDia());
        moveToPlayer = true;
        sGOAT_InterationComplete = false;
        yield return new WaitForSeconds(4.5f);
        moveToPlayer = false;
        vc_interaction.followSGOAT = false;
        yield return new WaitForSeconds(24f);
        flipx = true;
        moveFromPlayer = true;
        yield return new WaitForSeconds(3f);
        dialogbox.SetActive(false);
        sGOAT_InterationComplete = true;
        yield return new WaitForSeconds(2f);
        moveFromPlayer = false;
    }



    IEnumerator GoatComingDia()
    {
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: ?";
        yield return new WaitForSeconds(3.5f);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “Hey man.”";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “Sup?”";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “This place is totaled. There’s nothing left for me here. I don’t even know how I goat here.”";
        yield return new WaitForSeconds(3f);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “Grrrrrrrrrrwl”";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “What was that?”";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “Nothing, just a burp.”";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = " This man audibly emoted his hunger ";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “I see. You’ve got any idea where the grasslands are? I’ve been skateboarding through the snow for an hour.”";
        yield return new WaitForSeconds(4f);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “Yeah I do.”";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "He is LYING";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “Wait for me here, I’m gonna get something and be right back.”";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “Peace.”";
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "Search For FireWood under Trees";
        yield return new WaitForSeconds(4f);

    }

    void Interactables.Interact()
    {
        if (interaction0)
        {
            StartCoroutine(Interaction0());
        }
        if (interaction1)
        {
            StartCoroutine(Interaction1());
        }
    }
    IEnumerator Interaction0()
    {
        dialogbox.SetActive(true);
        sGOAT_InterationComplete = false;
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: Come back after completing your work, I'll wait! \n\t <Search For FireWood under Trees>";
        yield return new WaitForSeconds(3f);
        sGOAT_InterationComplete = true;
        dialogbox.SetActive(false);
    }
    IEnumerator Interaction1()
    {
        dialogbox.SetActive(true);
        sGOAT_InterationComplete = false;
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “I’m back, this place is getting cold, let’s make a toast before sending you off yeah?”";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(4f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “A toast for me.” ";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “Of course.”";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “Can I marry you?”";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “What?”";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “What?”";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogbox.GetComponentInChildren<Text>().text = "Bob starts a fire. Time passes by.";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(1f);
        dialogbox.SetActive(true);
        Instantiate(campFire, campLocation);
        yield return new WaitForSeconds(2.5f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “You gotta be kidding me with this toast nonsense. We've been sitting here for 20 minutes. Tell me where the grasslands are and I’m out.”";
        yield return new WaitForSeconds(5f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “Thought I could use some company but sure, keep heading on this path and you’ll find the grasslands.”";
        yield return new WaitForSeconds(3.5f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "GOAT: “I’m out.”";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(1f);
        moveToCamp = true;
        dialogbox.SetActive(false);
        yield return new WaitForSeconds(2f);
        moveToCamp = false;
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: “LMAOOOOO this animal is dumb as hell.”";
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogbox.SetActive(true);
        dialogbox.GetComponentInChildren<Text>().text = "Bob: Let's eat and get goin \n\t <Eat and Get to the house>";
        yield return new WaitForSeconds(2f);
        sGOAT_InterationComplete = true;
        boxcollider.isTrigger=true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxcollider.enabled= false;
            sr.sprite = null;
            Destroy(gameObject);
        }
    }
}
