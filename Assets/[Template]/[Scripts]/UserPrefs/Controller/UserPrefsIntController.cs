using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App.User.Controller
{
    [RequireComponent(typeof(Button))]
    public class UserPrefsIntController : MonoBehaviour
    {
        public UserPrefsCollection UserPrefs;
        public string TargetField = "Filed";

        public int TargetValue = 0;
        public Text Displayer;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();

            InitValue();
            RegisterListener();
        }
        private void OnDestroy()
        {
            UnregisterListener();
        }
        private void InitValue()
        {
            if (this.Displayer != null)
            {
                Displayer.text = typeof(UserPrefsCollection).GetField(TargetField).GetValue(UserPrefs).ToString();
            }
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
            typeof(UserPrefsCollection).GetField(TargetField).SetValue(UserPrefs, TargetValue);
            Debug.Log($"{typeof(UserPrefsCollection).Name}.{typeof(UserPrefsCollection).GetField(TargetField)} …Ë÷√Œ™{TargetValue}");

            InitValue();

            UserPrefsEvents.ChangeUserPrefsValue();
        }
    }
}
