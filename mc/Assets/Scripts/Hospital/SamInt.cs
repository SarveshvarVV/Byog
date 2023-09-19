using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamInt : MonoBehaviour, Interactables
{
    [SerializeField] GameObject dialog;
    [SerializeField] PressButton pb;

    public void Interact()
    {
        if (pb.isDead)
        {
            StartCoroutine(TellDead());
        }
    }

    IEnumerator TellDead()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = false;
        dialog.SetActive(true);
        dialog.GetComponentInChildren<Text>().text = "“He is DED!!!”";
        yield return new WaitForSeconds(2f); 
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = true;
        dialog.SetActive(false);
    }
}
