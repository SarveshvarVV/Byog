using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnDialog : MonoBehaviour
{
    [SerializeField] GameObject dialog;
    bool next;
    // Start is called before the first frame update
    void Start()
    {
        next = GlobalControl.Instance.next;
        if (next)
        {
            StartCoroutine(Play());
        }
    }

    IEnumerator Play()
    {
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = false;
        yield return new WaitForSeconds(2f);
        dialog.SetActive(true);
        dialog.GetComponentInChildren<Text>().text = "Bob: “I’m outta here man I ain’t spending another second on this garbage.”";
        yield return new WaitForSeconds(3f);
        dialog.GetComponentInChildren<Text>().text = "Bob: “Wonder if there’s a washroom here.”";
        yield return new WaitForSeconds(2f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = true;
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
