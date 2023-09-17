using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bed : MonoBehaviour, Interactables
{

    [SerializeField] GameObject dialog;
    public void Interact()
    {
        StartCoroutine(bed());
    }


    IEnumerator bed()
    {
        dialog.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = false;
        dialog.GetComponentInChildren<Text>().text = "This is a Bed!!!";
        yield return new WaitForSeconds(2f);
        dialog.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
