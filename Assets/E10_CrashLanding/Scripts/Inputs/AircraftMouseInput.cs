using UnityEngine;

namespace E10_CrashLanding
{
    [RequireComponent(typeof(Aircraft))]
    public class AircraftMouseInput : MonoBehaviour
    {
        [SerializeField] private MouseButton _upButton = MouseButton.Left;

        private enum MouseButton { Left, Right, Up }

        private Aircraft _aircraft;

        private void Start()
        {
            _aircraft = transform.GetComponent<Aircraft>();
        }

        private void Update()
        {
            if (Input.GetMouseButton((int)_upButton))
            {
                _aircraft.Accelerate();
            }
        }
    }
}