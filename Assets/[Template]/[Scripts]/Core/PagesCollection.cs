using System;
using UnityEngine;
using App.UI;

[CreateAssetMenu(menuName = "App/UI/PagesCollection")]
public class PagesCollection : ScriptableObject
{
    [Serializable]public class Page
    {
        public string PageName = "Default";
        public PageBase PageObject;
        public string PageKey = "pages.";
    }
    public Page[] Pages;

    public PageBase GetPrefabByKey(string key)
    {
        foreach (var page in Pages)
        {
            if (page.PageKey == key)
                return page.PageObject;
        }
        Debug.LogError($"PageKey '{key}' ²»´æÔÚ");
        return null;
    }
}
