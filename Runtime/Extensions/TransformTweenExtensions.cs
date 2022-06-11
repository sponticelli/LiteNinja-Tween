using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public static class TransformTweenExtensions
    {
        #region Position

        public static async Task TweenPosition(this Transform transform, Vector3 to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = transform.position;
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) => { transform.position = v; }, Vector3.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task TweenPosition(this Transform transform, Vector3 to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await transform.TweenPosition(to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }

        #endregion

        #region LocalPosition
        

        public static async Task TweenLocalPosition(this Transform transform, Vector3 to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = transform.localPosition;
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) => { transform.localPosition = v; }, Vector3.LerpUnclamped,
                completeAction,
                cancellationToken);
        }

        public static async Task TweenLocalPosition(this Transform transform, Vector3 to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await transform.TweenLocalPosition(to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }

        #endregion
        
        #region Rotation 
        public static async Task TweenRotation(this Transform transform, Quaternion to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = transform.rotation;
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    transform.rotation = v;
                }, Quaternion.LerpUnclamped,
                completeAction,
                cancellationToken);
        }
        
        public static async Task TweenRotation(this Transform transform, Quaternion to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await transform.TweenRotation(to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }
        
        #endregion
        
        #region Local Rotation 
        public static async Task TweenLocalRotation(this Transform transform, Quaternion to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = transform.localRotation;
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    transform.localRotation = v;
                }, Quaternion.LerpUnclamped,
                completeAction,
                cancellationToken);
        }
        
        public static async Task TweenLocalRotation(this Transform transform, Quaternion to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await transform.TweenLocalRotation(to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }
        
        #endregion

        #region scale
        public static async Task TweenScale(this Transform transform, Vector3 to,
            float time, Tween.EaseFunc easeFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            var from = transform.localScale;
            var tween = new Tween();
            await tween.Start(easeFunc, from, to, time, (v) =>
                {
                    transform.localScale = v;
                }, Vector3.LerpUnclamped,
                completeAction,
                cancellationToken);
        }
        
        public static async Task TweenScale(this Transform transform, Vector3 to,
            float time, AnimationCurve animationCurve, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            await transform.TweenScale(to, time, animationCurve.Evaluate, completeAction, cancellationToken);
        }
        

        #endregion
    }
    
}