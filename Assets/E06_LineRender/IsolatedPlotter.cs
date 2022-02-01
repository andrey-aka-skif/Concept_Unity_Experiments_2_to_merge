using System.Collections.Generic;
using UnityEngine;

namespace E06_Plotter
{
    public class IsolatedPlotter : MonoBehaviour
    {
        [SerializeField] private Transform _line;

        [SerializeField] private float _speed = 1;
        [SerializeField] private float _step = 0.1f;
        [SerializeField] private float _width = 25f;

        [SerializeField] private float _minValue = -1;
        [SerializeField] private float _maxValue = 1;

        private LineRenderer _lineRenderer;

        private Queue<float> _values;
        private Vector3[] _points;
        readonly System.Random _rnd = new System.Random();

        public float Speed => _speed;

        private int PointsCount => (int)(_width / _step) + 1;

        private void Awake()
        {
            _lineRenderer = GetComponentInChildren<LineRenderer>();
            _lineRenderer.positionCount = PointsCount;

            _values = new Queue<float>(PointsCount);
            _points = new Vector3[PointsCount];

            SetValuesFirst();
            SetPointsPositions();
            _lineRenderer.SetPositions(_points);
        }

        private void Update()
        {
            _line.Translate(_speed * Time.deltaTime * Vector3.left);

            if (_line.localPosition.x < -_step)
            {
                //_line.localPosition = Vector3.zero;

                AddNewValue();
                SetPointsPositions();
                _lineRenderer.SetPositions(_points);
            }
        }

        private void AddNewValue()
        {
            _values.Dequeue();
            _values.Enqueue(GetRndValue());
        }

        private void SetPointsPositions()
        {
            int i = 0;

            foreach (float value in _values)
            {
                _points[i] = new Vector3(_step * ++i, value, 0);
            }
        }

        private void SetValuesFirst()
        {
            for (int i = 0; i < PointsCount; i++)
            {
                _values.Enqueue(0);
            }
        }

        private float GetRndValue()
        {
            return (float)(_rnd.NextDouble() * (_maxValue - _minValue) + _minValue);
        }
    }
}