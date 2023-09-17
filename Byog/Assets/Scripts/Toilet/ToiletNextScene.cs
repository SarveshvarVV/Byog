using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToiletNextScene : MonoBehaviour, Interactables
{
    [SerializeField] GameObject dialog;
    [SerializeField] GameObject black;

    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator comeBlack()
    {
        dialog.SetActive(true);
        dialog.GetComponentInChildren<Text>().text = "Bob reaches out to his zip and pulls it down, fresh with excitement of leaving a heavy burden behind. With a huge sigh of relief,";
        yield return new WaitForSeconds(4f);
        dialog.SetActive(false);
        black.SetActive(true);
        //play lightsoff audio
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TD_House_wet_scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        StartCoroutine(comeBlack());
    }
}
