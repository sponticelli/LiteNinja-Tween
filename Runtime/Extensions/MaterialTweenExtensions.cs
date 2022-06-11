using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public static class MaterialTweenExtensions
    {
        public static async Task Tween(this Material material, string floatParamName,  float to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = material.GetFloat(floatParamName);
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    material.SetFloat(floatParamName, v);
                }, Mathf.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task Tween(this Material material, string floatParamName,  float to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await material.Tween(floatParamName, to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }
    }
}