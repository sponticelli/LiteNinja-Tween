using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public static class Vector3TweenExtensions
    {
        public static async Task Tween(this Vector3 vector, Vector3 to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = vector;
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) => { vector.Set(v.x, v.y, v.z); }, Vector3.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task TweenPosition(this Vector3 vector, Vector3 to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await vector.Tween(to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }
    }
    
}