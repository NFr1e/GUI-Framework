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
        UIManager.Instance.LoadPage<WelcomePage>("Pages/WelcomeCanvas");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
