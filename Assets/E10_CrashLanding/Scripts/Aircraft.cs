using System;
using UnityEngine;

namespace E10_CrashLanding
{
    public class Aircraft : MonoBehaviour
    {
        private MyLogger _logger;

        public event Action Died;

        [SerializeField] private float _minPitch = -45;
        [SerializeField] private float _maxPitch = 45;

        [SerializeField] private float _minSpeed = 1;
        [SerializeField] private float _maxSpeed = 3;

        [SerializeField] private float _acceleration = .5f;

        private bool _isLanded;
        private bool _isAcceleratingNow;
        private float _flatFlySpeed;
        private float _groundSpeed;
        private float _trueAirSpeed;    // TODO: пересчитать всё относительно _trueAirSpeed
        private float _pitch;
        private float _altitude;

        public float GroundSpeed => _groundSpeed;
        public float Pitch => _pitch;
        public float Altitude => _altitude;

        public void Accelerate()
        {
            _isAcceleratingNow = true;
        }

        public void ApplyFatalDamage()
        {
            Died?.Invoke();
        }

        private void Start()
        {
            _isLanded = true;
            _isAcceleratingNow = false;
            _flatFlySpeed = (_maxSpeed + _minSpeed) / 2;

            _logger = new MyLogger();
        }

        private void Update()
        {
            if (_isAcceleratingNow)
                CalculateSpeedUp();
            else
                CalculateSpeedDown();

            CalculatePitch();
            CalculateAltitude();

            _isAcceleratingNow = false;

            print($"{GroundSpeed}\t{Pitch}\t{Altitude}\t{(_isLanded ? 1 : 0)}");
            _logger.Log(GroundSpeed, Pitch, Altitude, _isLanded);
        }

        private void CalculateSpeedUp()
        {
            _groundSpeed += _acceleration * Time.deltaTime;

            if (_groundSpeed > _maxSpeed)
                _groundSpeed = _maxSpeed;

            if (_isLanded && _groundSpeed > _flatFlySpeed)
                _isLanded = false;
        }

        private void CalculateSpeedDown()
        {
            _groundSpeed -= _acceleration * Time.deltaTime;

            if (_isLanded)
            {
                if (_groundSpeed < 0)
                {
                    _groundSpeed = 0;
                }
            }
            else
            {
                if (_groundSpeed < _minSpeed)
                {
                    _groundSpeed = _minSpeed;
                }
            }
        }

        private void CalculatePitch()
        {
            if (_isLanded)
                _pitch = 0;
            else
                _pitch = (_groundSpeed - _minSpeed) / (_maxSpeed - _minSpeed) * (_maxPitch - _minPitch) + _minPitch;
        }

        private void CalculateAltitude()
        {
            if (_isLanded)
            {
                _altitude = 0;
                return;
            }

            float angleInGrad = (Mathf.PI / 180) * _pitch;

            float dX = _groundSpeed * Time.deltaTime;
            float dY = dX * Mathf.Tan(angleInGrad);

            _altitude += dY;
        }
    }
}