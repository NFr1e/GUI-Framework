using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using App.UI;

namespace App.UI.Components
{
    public class TabbarManager : MonoBehaviour
    {
        [System.Serializable]
        public class TabItem
        {
            public string TabName;
            public string PageKey;
            public GameObject TabButton;
        }

        [SerializeField]
        private List<TabItem> tabs = new List<TabItem>();

        private string currentPanelPath;

        void Start()
        {
            foreach (var tab in tabs)
            {
                var button = tab.TabButton.GetComponent<Button>();
                button.onClick.AddListener(() => SwitchTab(tab.PageKey));
            }

            if (tabs.Count > 0) SwitchTab(tabs[0].PageKey);
        }

        public void SwitchTab(string targetPanelPath)
        {
            if (currentPanelPath == targetPanelPath) return;

            if (!string.IsNullOrEmpty(currentPanelPath))
            {
                UIManager.Instance.UnloadPage(currentPanelPath);
            }

            UIManager.Instance.LoadPage<PageBase>(targetPanelPath);
            currentPanelPath = targetPanelPath;

            UpdateTabButtons(targetPanelPath);
        }

        private void UpdateTabButtons(string activePanelPath)
        {
            foreach (var tab in tabs)
            {
                bool isActive = (tab.PageKey == activePanelPath);

                Transform indicatorTrnasform = tab.TabButton.transform.Find("IsSelected");
                Image indicator = indicatorTrnasform.gameObject.GetComponent<Image>();

                indicatorTrnasform.gameObject.SetActive(isActive);
                indicator.DOFade(isActive ? 1 : 0, 0.2f);
            }
        }
    }
}
