using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWoodCollector : MonoBehaviour, Interactables
{
    BoxCollider2D boxCollider;
    [SerializeField] GameObject dialog;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (boxCollider != null) 
        {
            if (collision.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    boxCollider.enabled = false;
                    Interact();
                }
            }
        }
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
