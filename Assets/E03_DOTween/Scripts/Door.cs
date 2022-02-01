using UnityEngine;

namespace E03_DOTween
{
    public class Door : MonoBehaviour, IOpenable
    {
        private IOpener _opener;

        public bool IsOpened => _opener.IsOpened;

        public bool IsClosed => _opener.IsClosed;

        private void Awake()
        {
            if (TryGetComponent(out _opener) == false)
            {
                throw new System.Exception("Не реализован способ открытия");
            }
        }

        public void Open() => _opener.Open();

        public void Close() => _opener.Close();
    }
}