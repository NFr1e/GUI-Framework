using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using App.UI;

namespace App
{
    [RequireComponent(typeof(Button))]
    public class ButtonLoadPage : MonoBehaviour
    {
        public string PageKey;
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
            _button.onClick.AddListener(CallLoadPage);
        }
        private void Unregister()
        {
            _button.onClick.RemoveAllListeners();
        }
        private void CallLoadPage()
        {
            Debug.Log($"{GetType().Name} Call Load {PageKey}");
            UIManager.Instance.LoadPage(PageKey);
        }
    }
}
