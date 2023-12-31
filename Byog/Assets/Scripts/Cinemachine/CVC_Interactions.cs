using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CVC_Interactions : MonoBehaviour
{

    CinemachineVirtualCamera vc;
    [SerializeField] GameObject player, sGOAT;

    public bool followSGOAT = false;

    // Start is called before the first frame update
    void Start()
    {
        vc= GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followSGOAT)
        {
            FollowSGOAT();
        }
        else
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        vc.Follow = player.transform;
    }

    private void FollowSGOAT()
    {
        vc.Follow = sGOAT.transform;
    }
}
