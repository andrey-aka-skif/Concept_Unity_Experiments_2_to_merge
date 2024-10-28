using UnityEngine;

namespace E13_HideAndSeek
{
    namespace Watchan
    {

        [RequireComponent(typeof(CharacterController))]
        public class CharController : MonoBehaviour
        {
            private CharacterController _controller;
            private Vector3 _moveDirection;
            private float _speed;

            private void Start()
            {
                _controller = GetComponent<CharacterController>();
            }

            private void Update()
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    _moveDirection = transform.forward * _speed;
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    _moveDirection = -transform.forward * _speed;
                }
                else
                {
                    _moveDirection = Vector3.zero;
                }

                if (Input.GetAxis("Jump") > 0)
                { }
            }
        }
    }
}
