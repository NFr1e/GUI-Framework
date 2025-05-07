using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App.UI.Components
{
    [RequireComponent(typeof(Button))]
    public class ButtonOpenURL : MonoBehaviour
    {
        public string TargetURL;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OpenTargetURL);
        }
        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
        private void OpenTargetURL()
        {
            if(!string.IsNullOrEmpty(TargetURL))
                Application.OpenURL(TargetURL);
        }
    }
}
