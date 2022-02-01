using System.Collections.Generic;
using UnityEngine;

namespace E06_Plotter
{
    public class Plotter : MonoBehaviour
    {
        [SerializeField] private Transform _line;

        [SerializeField] private float _speed = 1;
        [SerializeField] private float _step = 0.2f;
        [SerializeField] private float _width = 25f;

        private Queue<float> _values;
        private Vector3[] _points;
        private float _nextValue;

        private LineRenderer _lineRenderer;
        readonly System.Random _rnd = new System.Random();
        [SerializeField] private float _minValue = -1;
        [SerializeField] private float _maxValue = 1;

        public float Speed => _speed;
        public float Width => _width;

        private int PointsCount => (int)(_width / _step) + 1;

        private void Awake()
        {
            _lineRenderer = GetComponentInChildren<LineRenderer>();
            _points = new Vector3[PointsCount];
            SetValuesFirst();
            SetPointsPositions();
            SetLineRenderer();
        }

        private void Update()
        {
            _line.Translate(new Vector3(-1 * _speed * Time.deltaTime, 0, 0));

            if (_line.localPosition.x < -_step)
            {
                _line.localPosition = Vector3.zero;
                AddNewValue();
                SetPointsPositions();
                _lineRenderer.SetPositions(_points);
            }
        }

        public void Recive(float value)
        {
            //_nextValue = value;
        }

        private void AddNewValue()
        {
            _values.Dequeue();
            //_values.Enqueue(_nextValue);
            _values.Enqueue(GetRndValue());
        }

        private void SetLineRenderer()
        {
            _lineRenderer.positionCount = PointsCount;
            _lineRenderer.SetPositions(_points);
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
            _values = new Queue<float>(PointsCount);

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