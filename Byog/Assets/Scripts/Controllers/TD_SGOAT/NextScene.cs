using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    BoxCollider2D boxCollider;

    private void Start()
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
                SceneManager.LoadScene("Arcade");
            }
        }
    }
}
