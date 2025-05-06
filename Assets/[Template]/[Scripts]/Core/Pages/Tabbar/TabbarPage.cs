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

        private float _offset;

        public override void OnEnter()
        {
            _tabbarOrigin = Tabbar.position;
            _offset = Tabbar.rect.height;

            Tabbar.position = new(_tabbarOrigin.x, _tabbarOrigin.y - _offset, _tabbarOrigin.z);

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
            _tweenIn = Tabbar
                .DOMove(_tabbarOrigin, DurationIn)
                .SetEase(EaseIn);

            yield return _tweenIn;
        }
        public override IEnumerator ExitAnimate()
        {
            yield return new WaitForSeconds(1);

            _tweenOut = Tabbar
                .DOMove(new(_tabbarOrigin.x, _tabbarOrigin.y - _offset, _tabbarOrigin.z),DurationOut)
                .SetEase(EaseOut);

            yield return _tweenOut.WaitForCompletion();
        }
    }
}
