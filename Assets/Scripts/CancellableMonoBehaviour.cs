using System.Threading;
using UnityEngine;

namespace com.liteninja.tweens.demo
{
    public abstract class CancellableMonoBehaviour : MonoBehaviour
    {
        protected CancellationTokenSource _cancellationTokenSource = null;

        protected void ResetCancellationToken()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
            _cancellationTokenSource = new CancellationTokenSource();
        }


        protected virtual void OnDisable()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }

        protected virtual  void OnApplicationQuit()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
        
    }
}