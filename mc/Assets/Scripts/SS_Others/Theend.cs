using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Theend : MonoBehaviour
{

    BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(box != null)
        {
            if (collision.CompareTag("Player"))
            {
                box.enabled = false;
                SceneManager.LoadScene("TD_Arcade");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
