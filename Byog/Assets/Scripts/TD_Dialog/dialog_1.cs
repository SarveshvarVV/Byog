using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog_1 : MonoBehaviour, Interactables
{

    BoxCollider2D boxCollider;
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
                Interact();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        TD_SGOAT_Spawn.diaTrig = true;
        DialogManager.Instance.ShowDialog(dialog[0]);
    }
}
