using UnityEngine;

namespace E03_DOTween
{
    public class OpenerByLerp : MonoBehaviour, IOpener
    {
        [SerializeField] private float _closedAngle = 0f;
        [SerializeField] private float _openedAngle = 90f;
        [SerializeField] private float _movingTime = 3f;

        private Quaternion _closedRotation = Quaternion.identity;
        private Quaternion _openedRotation = Quaternion.Euler(0, 90, 0);
        private float _t = 0f;

        private bool _isOpening = false;
        private bool _isClosings = false;

        private void Awake()
        {
            _closedRotation = Quaternion.Euler(0, _closedAngle, 0);
            _openedRotation = Quaternion.Euler(0, _openedAngle, 0);
        }

        public bool IsOpened { get; private set; } = false;

        public bool IsClosed { get; private set; } = true;

        public void Close()
        {
            if (IsOpened)
            {
                _isClosings = true;
                IsOpened = false;
            }
        }

        public void Open()
        {
            if (IsClosed)
            {
                _isOpening = true;
                IsClosed = false;
            }
        }

        private void Update()
        {
            if (_isOpening) OpenEntity();

            if (_isClosings) CloseEntity();
        }

        private void OpenEntity()
        {
            _t += Time.deltaTime / _movingTime;
            transform.localRotation = Quaternion.Lerp(_closedRotation, _openedRotation, _t);

            if(_t >= 1)
            {
                _isOpening = false;
                IsOpened = true;
            }
        }

        private void CloseEntity()
        {
            _t -= Time.deltaTime / _movingTime;
            transform.localRotation = Quaternion.Lerp(_closedRotation, _openedRotation, _t);

            if (_t <= 0)
            {
                _isClosings = false;
                IsClosed = true;
            }
        }
    }
}