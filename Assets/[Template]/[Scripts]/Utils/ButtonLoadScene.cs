using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace App
{
    [RequireComponent(typeof(Button))]
    public class ButtonLoadScene : MonoBehaviour
    {
        public int BuildIndex = 0;

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
            _button.onClick.AddListener(LoadScene);
        }
        private void Unregister()
        {
            _button.onClick.RemoveAllListeners();
        }
        private void LoadScene()
        {
            SceneManager.LoadScene(BuildIndex);
        }
    }
}
