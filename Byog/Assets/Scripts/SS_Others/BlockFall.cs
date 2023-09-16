using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFall : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Rigidbody2D rb2d;
    public bool touched = false;
    BlockFall_Trigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        trigger = GetComponentInChildren<BlockFall_Trigger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (boxCollider != null)
        {
            if (collision.CompareTag("Player"))
            {
                boxCollider.enabled = false;
                touched = true;
            }
            else
            {
                touched = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.fall)
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy");
            rb2d.gravityScale = 2f;
        }
    }
}
