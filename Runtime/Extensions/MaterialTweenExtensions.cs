using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace LiteNinja.Tweens
{
    public static class MaterialTweenExtensions
    {
        public static async Task Tween(this Material material, string floatParamName, float to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            var from = material.GetFloat(floatParamName);
            var tween = new Tween(timer);
            await tween.Start(easeFunc, from, to, time, (v) => { material.SetFloat(floatParamName, v); },
                Mathf.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task Tween(this Material material, string floatParamName, float to,
            float time, AnimationCurve animationCurve, Action completeAction = null, ITimer timer = null,
            CancellationToken cancellationToken = default)
        {
            await material.Tween(floatParamName, to, time, animationCurve.Evaluate, completeAction, timer,
                cancellationToken);
        }
    }
}