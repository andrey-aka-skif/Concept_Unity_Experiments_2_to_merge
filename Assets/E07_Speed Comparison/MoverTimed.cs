using UnityEngine;

namespace E07_SpeedComparison
{
    public class MoverTimed : MonoBehaviour
    {
        private readonly float _step = 0.1f;
        private readonly float _timeout = 0.1f;

        private float _lastTime;

        private void Start()
        {
            _lastTime = Time.time;
        }

        void Update()
        {
            if (Time.time - _lastTime >= _timeout)
            {
                /* Здесь _step - расстояние, пройденное за время _timeout */
                transform.Translate(_step * Vector3.left);
                _lastTime = Time.time;
            }
        }
    }
}