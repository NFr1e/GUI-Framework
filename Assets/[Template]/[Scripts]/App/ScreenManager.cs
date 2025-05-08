using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using App.User;
using App.User.Controller;

namespace App
{
    public class ScreenEvents
    {
        public static event System.Action OnScreenUpdate;
        public static void UpdateScreen() => OnScreenUpdate?.Invoke();
    }
    public class ScreenManager : Singleton<ScreenManager>
    {
        public class CurrentScreen
        {
            public static Vector2 CurrentResolution
            {
                get
                {
                    return new Vector2(Screen.width, Screen.height);
                }
            }
            public static bool IsFullScreen => Screen.fullScreen;
        }
        [SerializeField] private UserPrefsCollection _userPrefs;
        [SerializeField] private bool _isFullScreen = true;
        [SerializeField] private int _targetFrameRate = 240;
        [SerializeField] private int _targetRefreshRate = 240;

        [SerializeField,BoxGroup("PC Only")] private int 
            _width = 1400,
            _height = 3200;

        private void Start()
        {
            if (!UserPrefsEvents.PrefsLoaded) return;

            _isFullScreen = _userPrefs.UseFullScreen;
            _targetFrameRate = _userPrefs.TargetFrameRate;
            _targetRefreshRate = _userPrefs.TargetRefreshRate;

            UpdateCurrentScreen();
        }

        public void UpdateCurrentScreen()
        {
            Application.targetFrameRate = _targetFrameRate;

            if (_isFullScreen)
                Screen.SetResolution((int)CurrentScreen.CurrentResolution.x, (int)CurrentScreen.CurrentResolution.y, true,_targetRefreshRate);
            else
                Screen.SetResolution(_height, _width, false, _targetRefreshRate);

            ScreenEvents.UpdateScreen();
        }
    }
}
