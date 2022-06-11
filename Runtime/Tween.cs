using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace com.liteninja.tweens
{
    public class Tween
    {
        public delegate float EaseFunc(float f1);
        public delegate T LerpFunc<T>(T from, T to, float v);
        
        private CancellationTokenSource _cancellationTokenSrc = null;
        private ITimer _timer;

        public Tween(ITimer timer = null)
        {
            _timer = timer ?? new UnityTimer();
        }

        public CancellationTokenSource GetCancellationTokenSource(CancellationToken cancellationToken)
        {
            if (_cancellationTokenSrc == null)
            {
                _cancellationTokenSrc = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            }
            else
            {
                if (_cancellationTokenSrc.IsCancellationRequested)
                {
                    _cancellationTokenSrc = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                }
            }

            return _cancellationTokenSrc;
        }

        public void Cancel()
        {
            _cancellationTokenSrc?.Cancel();
            _cancellationTokenSrc?.Dispose();
            _cancellationTokenSrc = null;
        }

        public async Task Start<T>(EaseFunc easeFunc, T from, T to, float time,
            Action<T> updateAction, LerpFunc<T> lerpFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            _cancellationTokenSrc = GetCancellationTokenSource(cancellationToken);
            await Execute(easeFunc, 0, 1, time, (v) =>
            {
                var t = lerpFunc(from, to, v);
                updateAction(t);
            }, completeAction, _cancellationTokenSrc.Token);
        }


        public async Task Start<T>(AnimationCurve animationCurve, T from, T to, float time,
            Action<T> updateAction, LerpFunc<T> lerpFunc, Action completeAction = null,
            CancellationToken cancellationToken = default)
        {
            _cancellationTokenSrc = GetCancellationTokenSource(cancellationToken);
            await Start(animationCurve.Evaluate, from, to, time, updateAction, lerpFunc, completeAction, cancellationToken);
        }

        private async Task Execute(EaseFunc easeFunc, float @from, float to, float time, Action<float> updateAction,
            Action completeAction, CancellationToken token)
        {
            try
            {
                var t = 0f;
                var d = to - from;
                var startTime = _timer.Time;
                if (d != 0)
                {
                    while (Application.isPlaying && t < time)
                    {
                        t = _timer.Time - startTime;
                        var per = t / time;
                        if (per >= 1)
                        {
                            updateAction(to);
                            completeAction?.Invoke();
                            break;
                        } // Complete

                        per = Mathf.Clamp01(per);
                        per = easeFunc(per);
                        await Task.Delay(20, token);
                        token.ThrowIfCancellationRequested();
                        updateAction(from + d * per);
                    }
                }
            }
            catch (OperationCanceledException e)
            {
                Debug.Log($"Tween Canceled: " + e);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}