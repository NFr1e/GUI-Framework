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
        /// �����ҳ��ʱ����
        /// </summary>
        public abstract void OnEnter();
        /// <summary>
        /// �۽���ҳ��ʱÿ֡����
        /// </summary>
        public abstract void OnUpdate();
        /// <summary>
        /// �뿪��ҳ��ʱ����
        /// </summary>
        public abstract void OnExit();
        /// <summary>
        /// ҳ��ʧ��ʱ����
        /// </summary>
        public abstract void OnPause();
        /// <summary>
        /// ҳ��۽�ʱ����
        /// </summary>
        public abstract void OnResume();

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
