using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public static class ColorTweenExtensions
    {
        public static async Task Tween(this Color color, Color to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = color;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    color.r = v.r;
                    color.g = v.g;
                    color.b = v.b;
                    color.a = v.a;
                }, Color.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task Tween(this Color color, Color to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await color.Tween(to, time, animationCurve.Evaluate, completeAction,  timer, cancellationToken);
        }
        
        public static async Task Tween(this Color32 color, Color32 to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = color;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    color.r = v.r;
                    color.g = v.g;
                    color.b = v.b;
                    color.a = v.a;
                }, Color32.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task Tween(this Color32 color, Color32 to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await color.Tween(to, time, animationCurve.Evaluate, completeAction, timer, cancellationToken);
        }
    }
}