using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App.UI;
using App.UI.Pages;
using App.User;
using App.User.Controller;

namespace App
{
    public class EnterAppSequence : MonoBehaviour
    {
        public string FirstPage = "pages.tabbar";
        public UserPrefsCollection UserPrefs;
        private bool _splashScreen { get; set; } = false;

        private void Start()
        {
            if (!UserPrefsEvents.PrefsLoaded) return;

            _splashScreen = UserPrefs.UseSplashScreen;

            if (_splashScreen)
            {
                UIManager.Instance.LoadPage("pages.splash");
                return;
            }
            UIManager.Instance.LoadPage(FirstPage);
        }
    }
}
