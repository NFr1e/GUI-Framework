using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using App.UI;

namespace App.UI.Pages
{
    public class WelcomePage : PageBase
    {
        public float 
            DurationEnter = 0.5f,
            DurationOut = 0.5f;
        public Ease 
            EaseIn = Ease.InSine, 
            EaseOut = Ease.OutSine;

        public Transform
            Title,
            SubTitle;

        public Button ExitTrigger;

        public int TargetSceneIndex = 1;

        private Tween
            _tweenIn,
            _tweenOut,
            _tweenTitleIn,
            _tweenTitleOut,
            _tweenSubTitleIn,
            _tweenSubTitleOut;

        private Vector3
                _titleOrigin,
                _subtitleOrigin;

        private float _offset = ScreenManager.CurrentScreen.CurrentResolution.y / 2;
        public override void OnEnter()
        {
            _titleOrigin = Title.position;
            _subtitleOrigin = SubTitle.position;

            Title.position = new(_titleOrigin.x, _titleOrigin.y - _offset, _titleOrigin.z);
            SubTitle.position = new(_subtitleOrigin.x, _subtitleOrigin.y - _offset, _subtitleOrigin.z);

            ExitTrigger?.onClick.AddListener(() =>
            {
                UIManager.Instance.UnloadPage("pages.welcome");
                UIManager.Instance.LoadPage("pages.tabbar");
            });

            StartCoroutine(EnterAnimate());
        }
        public override void OnUpdate()
        {
            
        }
        public override IEnumerator OnExit()
        {
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
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;

            _tweenIn?.Kill();
            _tweenTitleIn?.Kill();
            _tweenSubTitleIn?.Kill();

            _tweenIn = DOTween
                .To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 1, DurationEnter)
                .SetEase(EaseIn)
                .OnComplete(() =>
                {
                    _canvasGroup.alpha = 1;
                    _canvasGroup.blocksRaycasts = true;
                });

            _tweenTitleIn = Title
                .DOMove(_titleOrigin, 1f)
                .SetEase(Ease.OutExpo);

            yield return new WaitForSeconds(0.3f);

            _tweenSubTitleIn = SubTitle
                .DOMove(_subtitleOrigin, 1f)
                .SetEase(Ease.OutExpo);

            yield return _tweenSubTitleIn.WaitForCompletion();
        }
        public override IEnumerator ExitAnimate()
        {
            
            _canvasGroup.blocksRaycasts = false;

            _tweenOut?.Kill();
            _tweenTitleOut?.Kill();
            _tweenSubTitleOut?.Kill();

            _tweenSubTitleOut = SubTitle
                .DOScale(0.6f * Vector3.one, 0.7f)
                .SetEase(Ease.OutExpo);

            _tweenTitleOut = Title
                .DOScale(0.6f * Vector3.one, 0.7f)
                .SetEase(Ease.OutExpo);

            _tweenOut = DOTween
                .To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 0, DurationOut)
                .SetEase(EaseOut);

            yield return _tweenOut.WaitForCompletion();
        }
    }
}
