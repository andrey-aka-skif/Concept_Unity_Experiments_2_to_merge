using UnityEngine;

namespace E03_DOTween
{
    public class FakePlayer : MonoBehaviour
    {
        [SerializeField] private KeyCode _actionKey = KeyCode.F;

        private IOpenable _door;

        private void Awake()
        {
            if (TryGetComponent(out _door) == false)
            {
                throw new System.Exception("Нечего открывать");
            }
        }

        private void Update()
        {
            if (Input.GetKey(_actionKey))
            {
                if (_door.IsOpened)
                {
                    _door.Close();
                }

                if (_door.IsClosed)
                {
                    _door.Open();
                }
            }
        }
    }
}