using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using App;

namespace App.UI.Pages
{
    public class ChildLayerPageBase : PageBase
    {
        public Button ExitTrigger;

        public float
            DurationIn = 0.5f,
            DurationOut = 0.5f;
        public Ease
            EaseIn = Ease.OutExpo,
            EaseOut = Ease.OutExpo;

        public RectTransform
            PageRoot;

        private Tween
            _tweenFadeIn,
            _tweenMoveIn,
            _tweenFadeOut,
            _tweenMoveOut;
        private Vector3
                _pageRootOrigin;

        private float _offset = ScreenManager.CurrentScreen.CurrentResolution.x;

        public override void OnEnter()
        {
            _pageRootOrigin = PageRoot.position;
            PageRoot.position = new(_pageRootOrigin.x + _offset, _pageRootOrigin.y, _pageRootOrigin.z);

            ExitTrigger.onClick.AddListener(() =>
            {
                UIManager.Instance.UnloadPage(this);
            }
            );

            StartCoroutine(EnterAnimate());
        }
        public override void OnUpdate()
        {

        }
        public override IEnumerator OnExit()
        {
            Debug.Log($"{GetType().Name} is OnExit");

            yield return ExitAnimate();
        }
        public override void OnPause()
        {

        }
        public override void OnResume()
        {

        }
        public override IEnumerator EnterAnimate()
        {
            _tweenFadeIn?.Kill();
            _tweenMoveIn?.Kill();

            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = true;

            _tweenFadeIn = DOTween
                .To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 1, DurationIn)
                .SetEase(EaseIn)
                .OnComplete(() =>
                {
                    _canvasGroup.alpha = 1;
                });

            _tweenMoveIn = PageRoot
                .DOMove(_pageRootOrigin, DurationIn * 1.2f)
                .SetEase(Ease.OutExpo);

            yield return _tweenMoveIn.WaitForCompletion();
        }
        public override IEnumerator ExitAnimate()
        {
            _tweenFadeOut?.Kill();
            _tweenMoveOut?.Kill();

            _canvasGroup.blocksRaycasts = false;

            _tweenFadeOut = DOTween
                .To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 0, DurationOut)
                .SetEase(EaseOut);
            _tweenMoveOut = PageRoot
                .DOMove(new(_pageRootOrigin.x + _offset, _pageRootOrigin.y, _pageRootOrigin.z), DurationIn * 1.2f)
                .SetEase(Ease.OutExpo);

            yield return _tweenMoveOut.WaitForCompletion();
        }
    }
}
