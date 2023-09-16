using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockFall_Trigger : MonoBehaviour
{
    BoxCollider2D boxCollider;
    public bool fall = false;

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
                fall = true;
            }
            else
            {
                fall= false;
            }
        }
    }
}
