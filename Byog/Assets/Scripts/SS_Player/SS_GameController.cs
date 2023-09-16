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
    [SerializeField] bool playerIsDead = false;
    [SerializeField] GameObject Canvas;
    //Circle_Blob circle_Blob;
    //Flying_Blob flying_Blob;
    //BlockFall blockfall;
    //Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerAnimator = player.GetComponent<Animator>();
        //circle_Blob = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Circle_Blob>();
        //flying_Blob = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Flying_Blob>();
        //blockfall = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BlockFall>();
        //boundary = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Boundary>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (circle_Blob.touched || flying_Blob.touched || blockfall.touched || boundary.touched)
        //{
        //    playerIsDead = true;
        //}
        //else
        //{
        //    playerIsDead = false;
        //}
        if (playerIsDead)
        {
            StartCoroutine(playerkill());
        }
        else
        {
            disablePC = false;
        }
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

    IEnumerator playerkill()
    {
        disablePC = true;
        playerAnimator.enabled = true;
        playerAnimator.SetBool("Dead", true);
        yield return new WaitForSeconds(1.2f);
        Canvas.gameObject.SetActive(true);
    }
}
