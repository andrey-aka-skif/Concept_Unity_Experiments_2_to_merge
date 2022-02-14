using UnityEngine;

namespace E10_CrashLanding
{
    [RequireComponent(typeof(Aircraft))]
    public class AircraftTouchInput : MonoBehaviour
    {
        private Aircraft _aircraft;

        private void Start()
        {
            _aircraft = transform.GetComponent<Aircraft>();
        }

        private void Update()
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _aircraft.Accelerate();
            }
        }
    }
}