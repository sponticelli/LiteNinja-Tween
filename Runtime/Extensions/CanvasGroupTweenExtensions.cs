using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public static class CanvasGroupTweenExtensions
    {
        public static async Task TweenAlpha(this CanvasGroup canvasGroup, float to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = canvasGroup.alpha;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    canvasGroup.alpha = v;
                }, Mathf.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task TweenAlpha(this CanvasGroup canvasGroup, float to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await canvasGroup.TweenAlpha(to, time, animationCurve.Evaluate, completeAction, timer, cancellationToken);
        }
    }
}