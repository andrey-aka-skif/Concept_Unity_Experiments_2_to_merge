using UnityEngine;

namespace E13_HideAndSeek
{
    namespace Brackeys
    {
        public class PlayerMovement : MonoBehaviour
        {
            [SerializeField] private CharacterController _controller;
            [SerializeField] private float _speed = 12f;
            [SerializeField] private float _gravity = -9.81f;
            [SerializeField] private float _jumpHeight = 3f;

            private Vector3 _velocity;

            private void Update()
            {

                if (_controller.isGrounded && _velocity.y < 0)
                {
                    _velocity.y = -2f;
                }

                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                Vector3 move = transform.right * x + transform.forward * z;


                if (Input.GetButtonDown("Jump") && _controller.isGrounded)
                {
                    _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
                }

                if (_controller.isGrounded)
                    _controller.Move(move * _speed * Time.deltaTime);


                _velocity.y += _gravity * Time.deltaTime;
                _controller.Move(_velocity * Time.deltaTime);
            }
        }
    }
}
