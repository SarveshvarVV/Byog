using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class SS_GameController : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    bool disablePC = false;
    bool playerIsDead = false;
    Circle_Blob circle_Blob;
    Flying_Blob flying_Blob;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        circle_Blob = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Circle_Blob>();
        flying_Blob = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Flying_Blob>();

    }

    // Update is called once per frame
    void Update()
    {
        if (circle_Blob.touched || flying_Blob.touched)
        {
            playerIsDead = true;
        }
        else
        {
            playerIsDead = false;
        }
        if (playerIsDead)
        {
            disablePC = true;
            //death animation
            //lifes left UI
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
}
