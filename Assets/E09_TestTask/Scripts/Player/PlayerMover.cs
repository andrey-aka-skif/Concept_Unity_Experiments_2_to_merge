using UnityEngine;

namespace E09_TestTask
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Settings _settings;

        private float _verticalSpeed;
        private float _minHeight;
        private float _maxHeight;
        private bool _isMoveUp;

        private void Start()
        {
            _verticalSpeed = _settings.VerticalSpeed;
            _minHeight = _settings.MinHeight;
            _maxHeight = _settings.MaxHeight;
            _isMoveUp = false;

            transform.localPosition = new Vector3(
                                            transform.localPosition.x,
                                            _settings.MaxHeight,
                                            transform.localPosition.z);
        }

        private void Update()
        {
            if (_isMoveUp)
                Move(_verticalSpeed * Time.deltaTime);
            else
                Move(-_verticalSpeed * Time.deltaTime);

            _isMoveUp = false;
        }

        private void Move(float distance)
        {
            float newHeight = transform.localPosition.y + distance;

            if (newHeight > _maxHeight)
                newHeight = _maxHeight;

            if (newHeight < _minHeight)
                newHeight = _minHeight;

            transform.localPosition = new Vector3(
                                                    transform.localPosition.x,
                                                    newHeight,
                                                    transform.localPosition.z);
        }

        public void TryMoveUp()
        {
            _isMoveUp = true;
        }
    }
}