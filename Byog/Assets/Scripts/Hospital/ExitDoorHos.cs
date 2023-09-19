using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorHos : MonoBehaviour
{
    BoxCollider2D box;

    [SerializeField] PressButton pb;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (box != null)
        {
            if (pb.isDead)
            {
                if (collision.CompareTag("Player"))
                {
                    box.enabled = false;
                    SceneManager.LoadScene("TD_toilet");
                }
            }
        }
    }
}
