using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WakeUp : MonoBehaviour
{

    [SerializeField] GameObject dialog;

    [SerializeField] GameObject end;
    [SerializeField] GameObject cred;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wake());
    }

    IEnumerator Wake()
    {
        yield return new WaitForSeconds(0.5f);
        dialog.SetActive(true);
        dialog.GetComponentInChildren<Text>().alignment = TextAnchor.MiddleCenter;
        dialog.GetComponentInChildren<Text>().text = "Bob wakes up.";
        yield return new WaitForSeconds(4f);
        dialog.SetActive(false);
        end.SetActive(true);
        yield return new WaitForSeconds(6f);
        cred.SetActive(true);
        yield return new WaitForSeconds(10f);
        Application.Quit();
    }

}
