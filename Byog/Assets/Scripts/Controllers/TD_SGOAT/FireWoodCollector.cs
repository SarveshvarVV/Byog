using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWoodCollector : MonoBehaviour, Interactables
{
    [SerializeField] GameObject dialog;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void Interact()
    {
        StartCoroutine(Dialog());
    }

    IEnumerator Dialog() 
    { 
        dialog.SetActive(true);
        dialog.GetComponentInChildren<Text>().text = "FireWood Collected \n\t <Meet up with the Skating GOAT>";
        yield return new WaitForSeconds(4f);
        SGOAT_System.interaction1 = true;
        dialog.SetActive(false);
        Destroy(gameObject);
    }
}
