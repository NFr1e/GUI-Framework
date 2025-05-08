using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App
{
    [RequireComponent(typeof(Button))]
    public class ButtonUpdateScreen : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();

            Register();
        }
        private void OnDestroy()
        {
            Unregister();
        }

        private void Register()
        {
            _button.onClick.AddListener(CallUpdateScreen);
        }
        private void Unregister()
        {
            _button.onClick.RemoveAllListeners();
        }
        private void CallUpdateScreen()
        {
            ScreenManager.Instance.UpdateCurrentScreen();
        }
    }
}
