using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetGlobalData : MonoBehaviour
{

    BoxCollider2D boxCollider;
    bool next;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        next = GlobalControl.Instance.next;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(boxCollider != null)
        {
            if (collision.CompareTag("Player"))
            {
                if (next)
                {
                    boxCollider.enabled = false;
                    SceneManager.LoadScene("TD_hosp");
                }
            }
        }        
    }
}
