using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using App.UI;

namespace App.UI.Pages
{
    public class SplashPage : PageBase
    {
        public string NextPageKey = "pages.tabbar";

        public float
            DurationOut = 0.5f;
        public Ease
            EaseOut = Ease.OutExpo;

        public Transform
            Title,
            SubTitle;

        private Tween
            _tweenTitleIn,
            _tweenSubTitleIn,
            _tweenOut;
        private Vector3
                _titleOrigin,
                _subtitleOrigin;

        private float _offset = CurrentScreen.CurrentResolution().y / 4;

        public override void OnEnter()
        {
            _titleOrigin = Title.position;
            _subtitleOrigin = SubTitle.position;

            Title.position = new(_titleOrigin.x, _titleOrigin.y - _offset, _titleOrigin.z);
            SubTitle.position = new(_subtitleOrigin.x, _subtitleOrigin.y - _offset, _subtitleOrigin.z);

            StartCoroutine(EnterAnimate());
        }
        public override void OnUpdate()
        {

        }
        public override IEnumerator OnExit()
        {
            Debug.Log($"{GetType().Name} is OnExit");

            yield return ExitAnimate();

            LoadNextPage();
        }
        public override void OnPause()
        {

        }
        public override void OnResume()
        {

        }
        public override IEnumerator EnterAnimate()
        {
            _tweenTitleIn?.Kill();
            _tweenSubTitleIn?.Kill();

            _tweenTitleIn = Title
                .DOMove(_titleOrigin, 1f)
                .SetEase(Ease.OutExpo);

            yield return new WaitForSeconds(0.6f);

            _tweenSubTitleIn = SubTitle
                .DOMove(_subtitleOrigin, 1f)
                .SetEase(Ease.OutExpo)
                .OnComplete(() => 
                {
                    _tweenSubTitleIn.Complete();
                });

            yield return _tweenSubTitleIn.WaitForCompletion();

            UIManager.Instance.UnloadPage("pages.splash");
        }
        public override IEnumerator ExitAnimate()
        {
            yield return new WaitForSeconds(1);

            _tweenOut = DOTween
                .To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 0, DurationOut)
                .SetEase(EaseOut);

            yield return _tweenOut.WaitForCompletion();
        }

        private void LoadNextPage()
        {
            Debug.Log($"{GetType().Name} StartedLoad:{NextPageKey}");

            UIManager.Instance.LoadPage(NextPageKey);
        }
    }
}
