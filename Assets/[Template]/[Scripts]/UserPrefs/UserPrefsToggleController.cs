using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

namespace App.User.Controller
{
    public class UserPrefsEvents
    {
        public static bool PrefsLoaded = false;

        public static event System.Action OnValueChanged;

        public static void ChangeUserPrefsValue() => OnValueChanged?.Invoke();
    }

    [RequireComponent(typeof(Button))]
    public class UserPrefsToggleController : MonoBehaviour
    {
        public UserPrefsCollection UserPrefs;
        public string TargetField = "Filed";

        public LeanToggle Toggle;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();

            InitToggle();
            RegisterListener();
        }
        private void OnDestroy()
        {
            UnregisterListener();
        }
        private void InitToggle()
        {
            Toggle.On = (bool)typeof(UserPrefsCollection).GetField(TargetField).GetValue(UserPrefs);
        }

        private void RegisterListener()
        {
            _button.onClick.AddListener(SetValue);
        }
        private void UnregisterListener()
        {
            _button.onClick.RemoveAllListeners();
        }
        private void SetValue()
        {
            typeof(UserPrefsCollection).GetField(TargetField).SetValue(UserPrefs, Toggle.On);
            Debug.Log($"{typeof(UserPrefsCollection).Name}.{typeof(UserPrefsCollection).GetField(TargetField)} …Ë÷√Œ™{Toggle.On}");

            UserPrefsEvents.ChangeUserPrefsValue();
        }
    }
}
