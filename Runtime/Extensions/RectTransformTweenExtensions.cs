using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public static class RectTransformTweenExtensions
    {
        public static async Task TweenAnchoredPosition(this RectTransform rectTransform, Vector2 to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = rectTransform.anchoredPosition;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    rectTransform.anchoredPosition = v;
                }, Vector2.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task TweenAnchoredPosition(this RectTransform rectTransform, Vector2 to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await rectTransform.TweenAnchoredPosition(to, time, animationCurve.Evaluate, completeAction, timer, cancellationToken);
        }
        
        public static async Task TweenScale(this RectTransform rectTransform, Vector3 to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = rectTransform.localScale;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    rectTransform.localScale = v;
                }, Vector3.LerpUnclamped,
                completeAction,
                cancellationToken);
        }
        
        public static async Task TweenScale(this RectTransform rectTransform, Vector3 to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await rectTransform.TweenScale(to, time, animationCurve.Evaluate, completeAction, timer, cancellationToken);
        }
        
    }
}