using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfirePoof : MonoBehaviour
{
    BoxCollider2D boxCollider;
    bool bringin = false;

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
                Debug.Log("awdawd");
                bringin = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bringin)
        {
            StartCoroutine(bringing());
        }
    }

    IEnumerator bringing()
    {
        var target = GameObject.FindGameObjectWithTag("NPC");
        bringin = false;
        yield return new WaitForSeconds(4f);
        boxCollider.enabled = false;
        target.GetComponent<Animator>().SetTrigger("Poof");
        Destroy(gameObject);
    }
}
