using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using App.UI;

namespace App
{
    [RequireComponent(typeof(Button))]
    public class ButtonDoPageOnExit : MonoBehaviour
    {
        public string PageKey = "pages.";
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
            _button.onClick.AddListener(CallDoExit);
        }
        private void Unregister()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void CallDoExit()
        {
            UIManager.Instance.DoPageOnExit(PageKey);
        }
    }
}
