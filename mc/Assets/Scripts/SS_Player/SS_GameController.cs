using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TarodevController;
using UnityEngine;


public class SS_GameController : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    Animator playerAnimator;
    bool disablePC = false;
    public static bool playerIsDead = false;
    [SerializeField] GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerAnimator = player.GetComponent<Animator>();
        GlobalControl.Instance.next = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDead)
        {
            StartCoroutine(playerkill());
        }
        else
        {
            disablePC = false;
        }
        if(player != null){
            if (disablePC)
            {
                player.GetComponent<BoxCollider2D>().enabled = false;
                playerController.enabled = false;
            }
            else
            {
                player.GetComponent<BoxCollider2D>().enabled = true;
                playerController.enabled = true;
            }
        }
        
    }

    IEnumerator playerkill()
    {
        disablePC = true;
        playerAnimator.enabled = true;
        playerAnimator.SetBool("Dead", true);
        yield return new WaitForSeconds(1.2f);
        Canvas.gameObject.SetActive(true);
    }
}
