using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using App.UI;

namespace App.UI.Pages
{
    public class TabbarPage : PageBase
    {
        public float
            DurationIn = 0.5f,
            DurationOut = 0.5f;
        public Ease
            EaseIn = Ease.OutExpo,
            EaseOut = Ease.OutExpo;

        public RectTransform
            Tabbar;

        private Tween
            _tweenIn,
            _tweenOut;
        private Vector3
                _tabbarOrigin;
        private bool _initialized = false;

        private float _offset;

        private void Start()
        {
            
        }

        public override void OnEnter()
        {
            if (!_initialized) 
            {
                _offset = Tabbar.rect.height;
                _tabbarOrigin = Tabbar.position;

                _initialized = true;
            }
            
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
            _canvasGroup.interactable = true;

            _tweenIn = Tabbar
                .DOMove(_tabbarOrigin, DurationIn)
                .From(new Vector3(_tabbarOrigin.x, _tabbarOrigin.y - _offset, _tabbarOrigin.z))
                .SetEase(EaseIn);

            yield return _tweenIn;
        }
        public override IEnumerator ExitAnimate()
        {
            _canvasGroup.interactable = false;

            _tweenOut = Tabbar
                .DOMove(new(_tabbarOrigin.x, _tabbarOrigin.y - _offset, _tabbarOrigin.z),DurationOut)
                .SetEase(EaseOut);

            yield return _tweenOut.WaitForCompletion();
        }
    }
}
