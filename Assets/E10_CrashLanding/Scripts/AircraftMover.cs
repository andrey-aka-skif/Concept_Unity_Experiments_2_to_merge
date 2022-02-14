using UnityEngine;

namespace E10_CrashLanding
{
    [RequireComponent(typeof(Aircraft))]
    public class AircraftMover : MonoBehaviour
    {
        private Aircraft _aircraft;

        private void Start()
        {
            _aircraft = GetComponent<Aircraft>();
        }

        private void Update()
        {
            transform.localPosition = _aircraft.Altitude * Vector3.up;
            transform.localRotation = Quaternion.Euler(0, 0, _aircraft.Pitch);
        }
    }
}