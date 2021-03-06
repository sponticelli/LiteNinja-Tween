using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace LiteNinja.Tweens
{
    public static class QuaternionTweenExtensions
    {
        public static async Task Tween(this Quaternion quaternion, Quaternion to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = quaternion;
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    quaternion.Set(v.x, v.y, v.z,v.w);
                }, Quaternion.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task TweenPosition(this Quaternion quaternion, Quaternion to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await quaternion.Tween(to, time, animationCurve.Evaluate, completeAction, timer, cancellationToken);
        }
    }
}