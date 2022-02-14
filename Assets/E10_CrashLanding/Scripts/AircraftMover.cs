using UnityEngine;

namespace E10_CrashLanding
{
    public class AircraftMover : MonoBehaviour
    {
        private const float VERTICAL_SPEED = 1.0f;

        private bool _isMoveUp;
        private float _verticalSpeed;

        private void Start()
        {
            _isMoveUp = false;
            _verticalSpeed = VERTICAL_SPEED;
        }

        private void Update()
        {
            if (_isMoveUp)
                Move(_verticalSpeed * Time.deltaTime);
            else
                Move(-_verticalSpeed * Time.deltaTime);

            _isMoveUp = false;
        }

        public void TryMoveUp()
        {
            _isMoveUp = true;
        }

        private void Move(float distance)
        {
            float newHeight = transform.localPosition.y + distance;

            transform.localPosition = new Vector3(
                                                    transform.localPosition.x,
                                                    newHeight,
                                                    transform.localPosition.z);
        }
    }
}