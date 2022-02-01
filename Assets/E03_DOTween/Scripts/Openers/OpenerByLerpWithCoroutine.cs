using System.Collections;
using UnityEngine;

namespace E03_DOTween
{
    public class OpenerByLerpWithCoroutine : MonoBehaviour, IOpener
    {
        [SerializeField] private float _closedAngle = 0f;
        [SerializeField] private float _openedAngle = 90f;
        [SerializeField] private float _movingTime = 3f;

        private Quaternion _closedRotation = Quaternion.identity;
        private Quaternion _openedRotation = Quaternion.Euler(0, 90, 0);

        public bool IsOpened { get; private set; } = false;

        public bool IsClosed { get; private set; } = true;

        private void Awake()
        {
            _closedRotation = Quaternion.Euler(0, _closedAngle, 0);
            _openedRotation = Quaternion.Euler(0, _openedAngle, 0);
        }

        public void Close()
        {
            if (IsOpened)
            {
                StartCoroutine(CloseEntity());
            }
        }

        public void Open()
        {
            if (IsClosed)
            {
                StartCoroutine(OpenEntity());
            }
        }

        IEnumerator OpenEntity()
        {
            IsClosed = false;

            float counter = 0f;
            float t = 0f;

            while(counter < _movingTime)
            {
                t += Time.deltaTime / _movingTime;
                transform.localRotation = Quaternion.Lerp(_closedRotation, _openedRotation, t);

                counter += Time.deltaTime;
                yield return null;
            }

            IsOpened = true;
        }

        private IEnumerator CloseEntity()
        {
            IsOpened = false;

            float counter = 0f;
            float t = 1f;

            while (counter < _movingTime)
            {
                t -= Time.deltaTime / _movingTime;
                transform.localRotation = Quaternion.Lerp(_closedRotation, _openedRotation, t);

                counter += Time.deltaTime;
                yield return null;
            }

            IsClosed = true;
        }
    }
}