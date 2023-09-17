using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starting : MonoBehaviour
{
    [SerializeField] GameObject dialog;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = false;
        yield return new WaitForSeconds(2f);
        dialog.SetActive(true);
        dialog.GetComponentInChildren<Text>().text = "Bob: “I am gonna die. This cold is going to be the end of me.”";
        yield return new WaitForSeconds(2f);
        dialog.GetComponentInChildren<Text>().text = "Motivated by his desire to live, Bob is determined to gather wood for stoking his hearth. ";
        yield return new WaitForSeconds(3f);
        dialog.GetComponentInChildren<Text>().text = "As for where the hearth is, let’s not worry about it.";
        yield return new WaitForSeconds(2f);
        dialog.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
