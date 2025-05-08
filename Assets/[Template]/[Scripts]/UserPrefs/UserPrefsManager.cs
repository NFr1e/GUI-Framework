using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.User.Controller
{
    public class UserPrefsEvents
    {
        public static bool PrefsLoaded = false;

        public static event System.Action OnValueChanged;

        public static void ChangeUserPrefsValue() => OnValueChanged?.Invoke();
    }
    public class UserPrefsManager : MonoBehaviour
    {
        public UserPrefsCollection UserPrefs;

        private void Awake()
        {
            LoadUserPrefs();

            Register();
        }
        private void OnDisable()
        {
            Unregister();
        }
        private void LoadUserPrefs()
        {
            if (!UserPrefs.HasSaved)
            {
                UserPrefs.SavePrefs();
            }

            UserPrefs?.LoadPrefs();

            UserPrefsEvents.PrefsLoaded = true;
        }
        private void Register() => UserPrefsEvents.OnValueChanged += UserPrefs.SavePrefs;
        private void Unregister() => UserPrefsEvents.OnValueChanged -= UserPrefs.SavePrefs;
    }
}
