using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


namespace com.liteninja.tweens.demo
{
    public class DemoTransformController : CancellableMonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _duration = 1.5f;
        
        public void RunScale()
        {
            ResetCancellationToken();
            var _ = RandomScale();
        }

        public void RunMove()
        {
            ResetCancellationToken();
            var _ = RandomMove();
        }

        public void RunRotate()
        {
            ResetCancellationToken();
            var _ = RandomRotate();
        }

        public void RunParallel()
        {
            ResetCancellationToken();
            var _ = ExecParallel();
        }

        private async Task RandomMove()
        {
            var to = new Vector3(Random.Range(-2f, 2f), Random.Range(-1.5f, 1.5f), Random.Range(-2f, 2f));
            await _target.TweenLocalPosition(to, _duration, v => Easing.CircOut(v),
                cancellationToken: _cancellationTokenSource.Token);
        }

        private async Task RandomScale()
        {
            var to = Vector3.one * Random.Range(1f, 5f);
            await _target.TweenScale(to, _duration, v => Easing.ElasticIn(v),
                cancellationToken: _cancellationTokenSource.Token);
        }

        private async Task RandomRotate()
        {
            
            var to = Quaternion.AngleAxis(Random.Range(-720, 720), Vector3.up) * _target.rotation;
            await _target.TweenLocalRotation(to, _duration, v => Easing.BackIn(v),
                cancellationToken: _cancellationTokenSource.Token);
        }

        private async Task ExecParallel()
        {
            await Task.WhenAll(RandomMove(), RandomScale(), RandomRotate());
        }
    }
}