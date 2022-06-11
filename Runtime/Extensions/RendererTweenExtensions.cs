using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public static class RendererTweenExtensions
    {
        public static async Task TweenColor(this Renderer renderer, Color to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = renderer.material.color;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    renderer.material.color = v;
                }, Color.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task TweenColor(this Renderer renderer, Color to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await renderer.TweenColor(to, time, animationCurve.Evaluate, completeAction, timer, cancellationToken);
        }
    }
}