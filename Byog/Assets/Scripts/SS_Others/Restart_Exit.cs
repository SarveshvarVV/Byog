using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Exit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Arcade");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("CatMario");
        }
    }
}
