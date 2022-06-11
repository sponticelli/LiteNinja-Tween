using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public static class Vector2TweenExtensions
    {
        public static async Task Tween(this Vector2 vector,  Vector2 to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null, CancellationToken cancellationToken = default)
        {
            var from = vector;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) => { vector.Set(v.x, v.y); }, Vector2.LerpUnclamped,
                completeAction,
                cancellationToken);
        }
        
        public static async Task TweenPosition(this Vector2 vector,  Vector2 to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null, CancellationToken cancellationToken = default)
        {
            await vector.Tween( to, time, animationCurve.Evaluate, completeAction, timer, cancellationToken);
        }
    }
}