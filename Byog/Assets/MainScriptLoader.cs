using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainScriptLoader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("TD_House");
    }
}
