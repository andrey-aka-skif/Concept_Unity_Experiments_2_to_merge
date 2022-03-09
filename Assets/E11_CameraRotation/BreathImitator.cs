using UnityEngine;

namespace E11_CameraRotation
{
    public class BreathImitator : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [SerializeField] private float _minAngle = -5;
        [SerializeField] private float _maxAngle = 5;

        [SerializeField] private float _actionTime = 1.2f;

        private Quaternion _minRotation;
        private Quaternion _maxRotation;
        private float _elapsed = 0;
        private int _direction = -1;

        private void Start()
        {
            if (_target == null) _target = transform;

            _minRotation = Quaternion.Euler(_minAngle, 0, 0);
            _maxRotation = Quaternion.Euler(_maxAngle, 0, 0);
        }

        private void Update()
        {
            _elapsed += _direction * Time.deltaTime;

            if (_elapsed > _actionTime)
            {
                _elapsed = _actionTime;
                _direction = -1;
            }

            if (_elapsed < 0)
            {
                _elapsed = 0;
                _direction = 1;
            }

            transform.localRotation = Quaternion.Lerp(_minRotation, _maxRotation, _elapsed / _actionTime);
        }
    }
}
