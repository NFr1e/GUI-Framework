using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace App.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private PagesCollection pagesCollection;

        [SerializeField]
        private Transform 
            PageLayer,
            PopupLayer,
            TipLayer;

        private Dictionary<string, PageBase> _pageCache = new();

        public void LoadPage(string pageKey)
        {
            if (_pageCache.ContainsKey(pageKey))
                _pageCache[pageKey].OnResume();
            else
            {
                PageBase prefab = pagesCollection.GetPrefabByKey(pageKey);
                if (prefab == null) return;

                GameObject pageObject = Instantiate(prefab.gameObject);
                PageBase page = pageObject.GetComponent<PageBase>();

                if (PageLayer != null)
                {
                    pageObject.transform.SetParent(PageLayer);
                }
                else
                {
                    Debug.LogWarning($"{pageKey} is loaded naked");
                }

                _pageCache.Add(pageKey,page);
                page.OnEnter();
            }
        }
        public void DoPageOnEnter(string pageKey)
        {
            if(_pageCache.TryGetValue(pageKey, out PageBase page))
            {
                page.OnEnter();
            }
        }
        public void UnloadPage(string pageKey)
        {
            if (_pageCache.TryGetValue(pageKey, out PageBase page))
            {
                StartCoroutine(UnloadProcess(page));

                _pageCache.Remove(pageKey);
            }
        }
        public void UnloadPage(PageBase page)
        {
            if(_pageCache.ContainsValue(page))
            {
                StartCoroutine(UnloadProcess(page));

                var keys= _pageCache.Where(kvp => kvp.Value == page).Select(kvp => kvp.Key).ToList();
                foreach(var key in keys)
                {
                    _pageCache.Remove(key);
                }
            }
        }
        public IEnumerator UnloadProcess(PageBase page)
        {
            yield return page.OnExit();

            if (page != null)
            {
                Destroy(page.gameObject);
            }
        }
        public void DoPageOnExit(PageBase page)
        {
            if (_pageCache.ContainsValue(page))
            {
                StartCoroutine(DoPageOnExitProcess(page));
            }
        }
        public void DoPageOnExit(string pageKey)
        {
            if (_pageCache.TryGetValue(pageKey, out PageBase page))
            {
                StartCoroutine(DoPageOnExitProcess(page));
            }
        }
        public IEnumerator DoPageOnExitProcess(PageBase page)
        {
            yield return page.OnExit();
        }
    }
}
