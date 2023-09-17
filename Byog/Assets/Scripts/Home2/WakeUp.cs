using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WakeUp : MonoBehaviour
{

    [SerializeField] GameObject dialog;

    [SerializeField] GameObject Text;

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
        Text.SetActive(true);
        yield return new WaitForSeconds(6f);
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
