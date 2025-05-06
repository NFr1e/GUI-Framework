using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.UI
{
    public interface IAnimatable
    {
        public IEnumerator EnterAnimate();
        public IEnumerator ExitAnimate();
    }

    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PageBase : MonoBehaviour , IAnimatable
    {
        protected CanvasGroup _canvasGroup;

        /// <summary>
        /// 进入该页面时调用
        /// </summary>
        public abstract void OnEnter();
        /// <summary>
        /// 聚焦该页面时每帧调用
        /// </summary>
        public abstract void OnUpdate();
        /// <summary>
        /// 页面失焦时调用
        /// </summary>
        public abstract void OnPause();
        /// <summary>
        /// 页面聚焦时调用
        /// </summary>
        public abstract void OnResume();
        /// <summary>
        /// 离开该页面时调用
        /// </summary>
        public virtual IEnumerator OnExit()
        {
            yield return ExitAnimate();
        }

        public virtual IEnumerator EnterAnimate()
        {
            yield break;
        }
        public virtual IEnumerator ExitAnimate()
        {
            yield break;
        }

        public virtual void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
}
