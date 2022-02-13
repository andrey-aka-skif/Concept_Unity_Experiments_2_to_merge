using UnityEngine;

namespace E09_TestTask
{
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private KeyCode _actionKey = KeyCode.Space;

        private PlayerMover _mover;

        private void Start()
        {
            _mover = transform.GetComponent<PlayerMover>();
        }

        private void Update()
        {
            if (Input.GetKey(_actionKey))
            {
                _mover.TryMoveUp();
            }
        }
    }
}