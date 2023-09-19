using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoCat : MonoBehaviour, Interactables
{

    [SerializeField] GameObject dialog;

    public void Interact()
    {
        StartCoroutine(goCat());
    }

    IEnumerator goCat()
    {
        dialog.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TD_Mover>().canMove = false;
        dialog.GetComponentInChildren<Text>().text = "Bob: “Sure, I’ll give it a shot.”";
        yield return new WaitForSeconds(3f);
        dialog.SetActive(false);
        SceneManager.LoadScene("FinalCatMario");
    }

}
