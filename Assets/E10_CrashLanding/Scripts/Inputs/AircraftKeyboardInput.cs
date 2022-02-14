using UnityEngine;

namespace E10_CrashLanding
{
    [RequireComponent(typeof(AircraftMover))]
    public class AircraftKeyboardInput : MonoBehaviour
    {
        [SerializeField] private KeyCode _upKey = KeyCode.Space;

        private AircraftMover _mover;

        private void Start()
        {
            _mover = transform.GetComponent<AircraftMover>();
        }

        private void Update()
        {
            if (Input.GetKey(_upKey))
            {
                _mover.TryMoveUp();
            }
        }
    }
}