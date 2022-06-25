using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.Tweens
{
    public static class MaskableGraphicExtensions
    {
        public static async Task Tween(this MaskableGraphic uiElement, Color to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = uiElement.color;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    uiElement.color = v;
                }, Color.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task Tween(this MaskableGraphic uiElement, Color to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await uiElement.Tween(to, time, animationCurve.Evaluate, completeAction, timer, cancellationToken);
        }
    }
}