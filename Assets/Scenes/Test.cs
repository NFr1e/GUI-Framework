using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using App.UI;
using App.UI.Pages;

public class Test : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.LoadPage<SplashPage>("Pages/SplashCanvas");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.LoadPage<WelcomePage>("Pages/WelcomeCanvas");
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
