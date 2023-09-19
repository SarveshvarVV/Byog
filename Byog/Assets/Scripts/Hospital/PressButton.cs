using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{
    [SerializeField] GameObject dialog;
    BoxCollider2D box;

    public bool isDead=false;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (box != null)
        {
            if (collision.CompareTag("Player"))
            {
                if(Input.GetKeyDown(KeyCode.F)) { 
                    box.enabled = false;
                    StartCoroutine(Kill());
                }
            }
        }
    }

    IEnumerator Kill()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = false;
        dialog.SetActive(true);
        dialog.GetComponentInChildren<Text>().text = "Kills Sam";
        yield return new WaitForSeconds(2f);
        dialog.GetComponentInChildren<Text>().text = "Bob has committed a casual homicide but it’s the least of his concern. He remembers something he had forgotten about. He had to pee. ";
        yield return new WaitForSeconds(5f);
        dialog.GetComponentInChildren<Text>().text = "Bob: “It’s over for me. WHERE IS THE TOILET???”";
        yield return new WaitForSeconds(3f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = true;
        dialog.SetActive(false);
        isDead = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
