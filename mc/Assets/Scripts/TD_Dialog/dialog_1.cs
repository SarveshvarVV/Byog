using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_1 : MonoBehaviour
{
    BoxCollider2D boxCollider;
    [SerializeField] GameObject dialog;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (boxCollider != null)
        {
            if (collision.CompareTag("Player"))
            {
                boxCollider.enabled = false;
                StartCoroutine(Inter(collision));
            }
        }
    }
    IEnumerator Inter(Collider2D other)
    {
        dialog.SetActive(true);
        GameObject.FindGameObjectWithTag("NPC").GetComponent<SGOAT_System>().sGOAT_InterationComplete = false;
        dialog.GetComponentInChildren<Text>().text = "Bob: “Been a while since I’ve skateboarded”";
        yield return new WaitForSeconds(2f);
        GameObject.FindGameObjectWithTag("NPC").GetComponent<SGOAT_System>().sGOAT_InterationComplete=true;
        dialog.SetActive(false);
        Destroy(gameObject);
    }

}
