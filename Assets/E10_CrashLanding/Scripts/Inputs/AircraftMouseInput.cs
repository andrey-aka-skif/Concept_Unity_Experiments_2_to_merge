using UnityEngine;

namespace E10_CrashLanding
{
    [RequireComponent(typeof(AircraftMover), typeof(Aircraft))]
    public class AircraftMouseInput : MonoBehaviour
    {
        [SerializeField] private MouseButton _upButton = MouseButton.Left;

        private enum MouseButton { Left, Right, Up }

        //private AircraftMover _mover;
        private Aircraft _aircraft;

        private void Start()
        {
            //_mover = transform.GetComponent<AircraftMover>();
            _aircraft = transform.GetComponent<Aircraft>();
        }

        private void Update()
        {
            if (Input.GetMouseButton((int)_upButton))
            {
                //_mover.TryMoveUp();
                _aircraft.Accelerate
();
            }
        }
    }
}