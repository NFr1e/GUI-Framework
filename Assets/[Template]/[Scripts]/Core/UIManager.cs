using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.UI
{
    public class CurrentScreen
    {
        public static Vector2 CurrentResolution()
        {
            return new Vector2(Screen.width, Screen.height);
        }
    }
    public class UIManager : Singleton<UIManager>
    {
        public Transform 
            PageLayer,
            PopupLayer,
            TipLayer;

        private Dictionary<string, PageBase> _pageCache = new();

        public void LoadPage<T>(string pageKey) where T : PageBase
        {
            if (_pageCache.ContainsKey(pageKey))
                _pageCache[pageKey].OnResume();
            else
            {
                GameObject pageObject = Instantiate(Resources.Load<GameObject>(pageKey));
                T page = pageObject.GetComponent<T>();

                _pageCache.Add(pageKey,page);

                page.OnEnter();

                if(PageLayer != null)
                {
                    pageObject.transform.SetParent(PageLayer);
                }
                else
                {
                    Debug.LogWarning($"{pageKey} is loaded naked");
                }
            }
        }
        public void UnloadPage(string pageKey)
        {
            if (_pageCache.TryGetValue(pageKey, out PageBase page))
            {
                StartCoroutine(UnloadProcess(pageKey, page));
            }
        }
        public IEnumerator UnloadProcess<T>(string key,T page) where T : PageBase
        {
            yield return page.OnExit();

            if (page != null)
            {
                Destroy(page.gameObject);
            }

            _pageCache.Remove(key);
        }
    }
}
