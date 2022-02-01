using UnityEngine;

namespace E07_SpeedComparison
{
    public class MoverDeltaTime : MonoBehaviour
    {
        private readonly float _step = 0.1f;
        private readonly float _timeout = 0.1f;
        private float _speed;

        private void Start()
        {
            _speed = _step / _timeout;
        }

        void Update()
        {
            /* ����� _speed * Time.deltaTime - ����������, ���������� �� ����� Time.deltaTime */
            transform.Translate(_speed * Time.deltaTime * Vector3.left);
        }
    }
}