using UnityEngine;

namespace E07_SpeedComparison
{
    public class MoveStep : MonoBehaviour
    {
        [SerializeField] private Vector3 _vector = Vector3.left;
        [SerializeField] private float _timeStep = 0.1f;
        private float _timer;

        // test
        [SerializeField] private Move _move;
        private bool _isChange;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeStep)
            {
                transform.position += _vector * _timer;
                _timer -= _timeStep;
                _timer = 0;
                _isChange = true;
            }
        }

        // в конце кадра, когда Update обоих уже сработал
        private void LateUpdate()
        {
            if (_move != null && _isChange)
            {
                Debug.Log("M  " + _move.transform.position);
                Debug.Log("MS " + transform.position);
                _isChange = false;
            }
        }
    }
}