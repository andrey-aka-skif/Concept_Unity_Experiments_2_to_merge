using System;
using UnityEngine;

namespace E13_HideAndSeek
{
    namespace RigidbodyController
    {

        [RequireComponent(typeof(Rigidbody))]
        public class FPVController : MonoBehaviour
        {
            [SerializeField] private Camera _fpvCamera;

            [SerializeField] private float _moveSpeed = 6.0f;
            [SerializeField] private float _movementMultiplier = 10.0f;
            [SerializeField] private float _airMultiplier = 0.4f;



            [SerializeField] private float _groundDrug = 6.0f;
            [SerializeField] private float _airDrug = 2.0f;

            private float _hirizonralMovement;
            private float _verticalMovement;

            private Vector3 _moveDirection;

            private Rigidbody _rb;



            [SerializeField] private float _sensX = 100f;
            [SerializeField] private float _sensY = 100f;

            private float _mouseX;
            private float _mouseY;

            private float _multiplier = 0.01f;

            private float _xRotation;
            private float _yRotation;


            private bool _isGrounded;
            private float _playerHeight = 2f;

            [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
            [SerializeField] private float _jumpForce = 5f;

            private void Start()
            {
                _fpvCamera = _fpvCamera != null ? _fpvCamera : GetComponentInChildren<Camera>();

                if (_fpvCamera == null) throw new Exception();

                _rb = GetComponent<Rigidbody>();
                _rb.freezeRotation = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            private void Update()
            {
                _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight / 2 + 0.1f);


                GetInput();
                ControlDrag();

                _fpvCamera.transform.localRotation = Quaternion.Euler(-_xRotation, 0f, 0f);
                transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);

                if (Input.GetKeyDown(_jumpKey) && _isGrounded)
                {
                    Jump();
                }
            }

            private void Jump()
            {
                _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            }

            private void GetInput()
            {
                _verticalMovement = Input.GetAxis("Vertical");
                _hirizonralMovement = Input.GetAxis("Horizontal");

                _moveDirection = transform.forward * _verticalMovement + transform.right * _hirizonralMovement;

                _mouseX = Input.GetAxis("Mouse X");
                _mouseY = Input.GetAxis("Mouse Y");

                _yRotation += _mouseX * _sensX * _multiplier;
                _xRotation += _mouseY * _sensY * _multiplier;

                _xRotation = Mathf.Clamp(_xRotation, -90.0f, 90.0f);
            }

            private void ControlDrag()
            {
                if (_isGrounded)
                {
                    _rb.drag = _groundDrug;
                }
                else
                {
                    _rb.drag = _airDrug;
                }

            }

            private void FixedUpdate()
            {
                MovePlayer();
            }

            private void MovePlayer()
            {
                if (_isGrounded)
                {
                    _rb.AddForce(_movementMultiplier * _moveSpeed * _moveDirection.normalized, ForceMode.Acceleration);
                }
                else
                {
                    _rb.AddForce(_airMultiplier * _moveSpeed * _moveDirection.normalized, ForceMode.Acceleration);
                }

            }
        }
    }
}
