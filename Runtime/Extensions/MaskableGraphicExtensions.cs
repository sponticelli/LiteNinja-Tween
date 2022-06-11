using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace com.liteninja.tweens
{
    public static class MaskableGraphicExtensions
    {
        public static async Task Tween(this MaskableGraphic uiElement, Color to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = uiElement.color;
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    uiElement.color = v;
                }, Color.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task Tween(this MaskableGraphic uiElement, Color to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await uiElement.Tween(to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }
    }


    public static class CanvasGroupExtensions
    {
        public static async Task TweenAlpha(this CanvasGroup canvasGroup, float to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = canvasGroup.alpha;
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    canvasGroup.alpha = v;
                }, Mathf.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task TweenAlpha(this CanvasGroup canvasGroup, float to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await canvasGroup.TweenAlpha(to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }
    }
}