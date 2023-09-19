using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HosStart : MonoBehaviour
{
    [SerializeField] GameObject dialog;
    BoxCollider2D box;
    
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (box != null)
        {
            if (collision.CompareTag("Player"))
            {
                box.enabled = false;
                StartCoroutine(PlayDia());
            }
        }
    }

    IEnumerator PlayDia()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = false;
        yield return new WaitForSeconds(2f);
        dialog.SetActive(true);
        dialog.GetComponentInChildren<Text>().text = "Bob: “Sam?”";
        yield return new WaitForSeconds(2f);
        dialog.GetComponentInChildren<Text>().text = "Sam: “Bob?”";
        yield return new WaitForSeconds(2f);
        dialog.GetComponentInChildren<Text>().text = "Bob: “Oh my god. How did this happen to you?”";
        yield return new WaitForSeconds(2f);
        dialog.GetComponentInChildren<Text>().text = "Sam: “idk”";
        yield return new WaitForSeconds(2f);
        dialog.GetComponentInChildren<Text>().text = "Sam: “9sdn;ojvbiw9201nowomen?iohfiohfvbkjnomen?uaohfi3-”";
        yield return new WaitForSeconds(4f);
        dialog.GetComponentInChildren<Text>().text = "Bob: “aight.”";
        yield return new WaitForSeconds(2f);
        dialog.GetComponentInChildren<Text>().text = "Press the button \n\t <Press F to push the Button>";
        yield return new WaitForSeconds(2f);
        dialog.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = true;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
