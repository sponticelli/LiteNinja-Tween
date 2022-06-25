using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace LiteNinja.Tweens.Demo
{

   
    
    public class DemoSimpleController : CancellableMonoBehaviour
    {
        [Header("UI")] [SerializeField] private TMP_Text _linearText;
        [SerializeField] private TMP_Text _curvedText;

        [Header("Tween")] [SerializeField] private float _duration = 5f;
        [SerializeField] private float _startingValue = 0f;
        [SerializeField] private float _endingValue = 1000f;


        
        private Tween _tween;


        public void Run()
        {
            Execute();
        }

        private async Task Execute()
        {
            ResetCancellationToken();

            _tween = new Tween();
            var t1 = _tween.Start((v) => Easing.Linear(v), _startingValue, _endingValue, _duration,
                (v) => { _linearText.text = Mathf.RoundToInt(v).ToString(); }, Mathf.Lerp,
                () => { Debug.Log("Linear Tween completed"); },
                _cancellationTokenSource.Token);

            var t2 = _tween.Start((v) => Easing.SineIn(v), _startingValue, _endingValue, _duration,
                (v) => { _curvedText.text = Mathf.RoundToInt(v).ToString(); }, Mathf.Lerp,
                () => { Debug.Log("SineIn Tween completed"); },
                _cancellationTokenSource.Token);

            await Task.WhenAll(t1, t2);

            await _tween.Start((v) => Easing.Linear(v), 0f, 100f, 5f,
                (v) => { Debug.Log(v); }, Mathf.Lerp, () => { Debug.Log("Tween completed"); },
                _cancellationTokenSource.Token);
        }

        private void OnEnable()
        {
            _linearText.text = _startingValue.ToString();
            _curvedText.text = _startingValue.ToString();
        }

        
    }
}