using DG.Tweening;
using UnityEngine;

namespace E03_DOTween
{
    public class OpenerByDOTween : MonoBehaviour, IOpener
    {
        [SerializeField] private float _closedAngle = 0f;
        [SerializeField] private float _openedAngle = 90f;
        [SerializeField] private float _movingTime = 3f;

        private Vector3 _closedVector = Vector3.zero;
        private Vector3 _openedVector = new Vector3(0, 90, 0);

        public bool IsOpened { get; private set; } = false;

        public bool IsClosed { get; private set; } = true;

        private void Awake()
        {
            _closedVector = new Vector3(0, _closedAngle, 0);
            _openedVector = new Vector3(0, _openedAngle, 0);
        }

        public void Close()
        {
            if (IsOpened)
            {
                transform
                    .DOLocalRotate(_closedVector, _movingTime)
                    .OnComplete(() =>
                    {
                        IsOpened = false;
                        IsClosed = true;
                    });

            }
        }

        public void Open()
        {
            if (IsClosed)
            {
                transform
                    .DOLocalRotate(_openedVector, _movingTime)
                    .OnComplete(() =>
                    {
                        IsClosed = false;
                        IsOpened = true;
                    });
            }
        }
    }
}