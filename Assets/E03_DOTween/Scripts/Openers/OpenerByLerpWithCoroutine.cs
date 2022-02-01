using System.Collections;
using UnityEngine;

namespace E03_DOTween
{
    public class OpenerByLerpWithCoroutine : MonoBehaviour, IOpener
    {
        [SerializeField] private float _closedAngle = 0f;
        [SerializeField] private float _openedAngle = 90f;
        [SerializeField] private float _movingTime = 3f;

        public bool IsOpened { get; private set; } = false;

        public bool IsClosed { get; private set; } = true;

        public void Close()
        {
            if (IsOpened)
            {
                StartCoroutine(MoveEntity(false));
            }
        }

        public void Open()
        {
            if (IsClosed)
            {
                StartCoroutine(MoveEntity(true));
            }
        }

        private IEnumerator MoveEntity(bool isOpening)
        {
            Quaternion closedRotation = Quaternion.Euler(0, _closedAngle, 0);
            Quaternion openedRotation = Quaternion.Euler(0, _openedAngle, 0);

            float counter = 0f;

            float t;
            int k;
            if (isOpening)
            {
                IsClosed = false;
                t = 0;
                k = 1;
            }
            else
            {
                IsOpened = false;
                t = 1;
                k = -1;
            }

            while (counter < _movingTime)
            {
                t += k * Time.deltaTime / _movingTime;
                transform.localRotation = Quaternion.Lerp(closedRotation, openedRotation, t);

                counter += Time.deltaTime;
                yield return null;
            }

            if (isOpening)
            {
                IsOpened = true;
            }
            else
            {
                IsClosed = true;
            }
        }
    }
}