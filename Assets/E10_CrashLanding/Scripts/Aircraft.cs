using System;
using UnityEngine;

namespace E10_CrashLanding
{
    public class Aircraft : MonoBehaviour
    {
        public event Action Died;

        [SerializeField] private float _minPitch = -45;
        [SerializeField] private float _maxPitch = 45;

        [SerializeField] private float _minSpeed = 1;
        [SerializeField] private float _maxSpeed = 3;

        [SerializeField] private float _acceleration = .5f;

        private float _flatFlySpeed;
        private bool _isAcceleratingNow = false;
        private bool _isLanded = true;
        private float _speed = 0;
        public float _altitude = 0;
        public float Speed
        {
            get => _speed;
            private set
            {
                _speed = value;

                if (_isLanded && _speed > _flatFlySpeed)
                    _isLanded = true;
            }
        }
        public float Pitch
        {
            get
            {
                if (_isLanded && _speed < _flatFlySpeed)
                    return 0;

                return (Speed - _minSpeed)
                        / (_maxSpeed - _minSpeed) * (_maxPitch - _minPitch) + _minPitch;
            }
        }

        public float Altitude
        {
            get
            {
                float dX = _speed * Time.deltaTime;
                float dY = dX * Mathf.Tan(Pitch);
                _altitude += dY;
                return _altitude;
            }
        }

        private void Start()
        {
            _flatFlySpeed = (_maxSpeed + _minSpeed) / 2;
        }

        private void Update()
        {
            if (_isAcceleratingNow)
                SpeedUp();
            else
                SpeedDown();

            _isAcceleratingNow = false;

            print($"Speed={Speed}, Pitch ={Pitch}, Altitude={Altitude}");
        }

        private void SpeedUp()
        {
            Speed += _acceleration * Time.deltaTime;

            if (Speed > _maxSpeed)
                Speed = _maxSpeed;
        }

        private void SpeedDown()
        {
            Speed -= _acceleration * Time.deltaTime;

            if (Speed < _minSpeed)
                Speed = _minSpeed;
        }

        public void Accelerate()
        {
            _isAcceleratingNow = true;
        }

        public void ApplyFatalDamage()
        {
            Died?.Invoke();
        }
    }
}