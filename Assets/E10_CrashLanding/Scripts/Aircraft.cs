using System;
using UnityEngine;

namespace E10_CrashLanding
{
    public class Aircraft : MonoBehaviour, IFatalDamageable
    {
        public event Action Died;

        [SerializeField] private float _minPitch = -45;
        [SerializeField] private float _maxPitch = 45;

        [SerializeField] private float _minSpeed = 1;
        [SerializeField] private float _maxSpeed = 3;

        [SerializeField] private float _acceleration = .5f;

        private bool _isLanded;
        private bool _isAcceleratingNow;
        private float _flatFlySpeed;

        private float _trueAirSpeed;
        private float _pitch;
        private float _groundSpeed;
        private float _rateOfClimb;
        private float _altitude;
        private float _traveledDistance;

        public float TrueAirSpeed => _trueAirSpeed;
        public float Pitch => _pitch;
        public float GroundSpeed => _groundSpeed;
        public float RateOfClimb => _rateOfClimb;
        public float Altitude => _altitude;
        public float TraveledDistance => _traveledDistance;

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
        }

        private void Update()
        {
            if (_isAcceleratingNow)
            {
                CalculateTrueAirSpeedUp();
            }
            else
            {
                CalculateTrueAirSpeedDown();
            }

            CalculatePitch();
            CalculateGroundSpeed();
            CalculateRateOfClimb();
            CalculateAltitude();
            CalculateTraveledDistance();

            _isAcceleratingNow = false;
        }

        private void CalculateTrueAirSpeedUp()
        {
            _trueAirSpeed += _acceleration * Time.deltaTime;

            if (_trueAirSpeed > _maxSpeed)
                _trueAirSpeed = _maxSpeed;

            if (_isLanded && _trueAirSpeed > _flatFlySpeed)
                _isLanded = false;
        }

        private void CalculateTrueAirSpeedDown()
        {
            _trueAirSpeed -= _acceleration * Time.deltaTime;

            if (_isLanded)
            {
                if (_trueAirSpeed < 0)
                {
                    _trueAirSpeed = 0;
                }
            }
            else
            {
                if (_trueAirSpeed < _minSpeed)
                {
                    _trueAirSpeed = _minSpeed;
                }
            }
        }

        private void CalculatePitch()
        {
            if (_isLanded)
                _pitch = 0;
            else
                _pitch = (_trueAirSpeed - _minSpeed) / (_maxSpeed - _minSpeed) * (_maxPitch - _minPitch) + _minPitch;
        }

        private void CalculateGroundSpeed()
        {
            float angleInRad = (Mathf.PI / 180) * _pitch;
            _groundSpeed = _trueAirSpeed * Mathf.Cos(angleInRad);
        }

        private void CalculateRateOfClimb()
        {
            float angleInRad = (Mathf.PI / 180) * _pitch;
            _rateOfClimb = _trueAirSpeed * Mathf.Sin(angleInRad);
        }

        private void CalculateAltitude()
        {
            _altitude += _rateOfClimb * Time.deltaTime;
        }

        private void CalculateTraveledDistance()
        {
            _traveledDistance += _groundSpeed * Time.deltaTime;
        }
    }
}