using UnityEngine;

namespace E06_Plotter
{
    public class Sender : MonoBehaviour
    {
        private enum Source { Rnd, AnimationCurve }

        [SerializeField] private Source _source = Source.Rnd;
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private Plotter _plotter;

        [Header("Rnd:")]
        [SerializeField] private float _minValue = -1;
        [SerializeField] private float _maxValue = 1;

        private float _nextValue;

        System.Random _rnd = new System.Random();

        private float _currentTime;
        private float _totalTime;

        private int _factor = -1;

        private void Start()
        {
            _totalTime = _curve.keys[_curve.keys.Length - 1].time;
        }

        private void FixedUpdate()
        {
            if (_source == Source.Rnd)
            {
                _nextValue = GetRndValue();
            }
            else if (_source == Source.AnimationCurve)
            {
                _nextValue = GetCurveValue();
            }

            _plotter.Recive(_nextValue);
        }

        private float GetRndValue()
        {
            return (float)(_rnd.NextDouble() * (_maxValue - _minValue) + _minValue);
        }

        private float GetCurveValue()
        {
            float value = _curve.Evaluate(_currentTime);

            _currentTime += Time.fixedDeltaTime;

            Debug.Log(value);

            _factor *= -1;

            return value * _factor;
        }
    }
}