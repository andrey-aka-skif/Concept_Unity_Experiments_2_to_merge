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
            transform.localRotation = Quaternion.Euler(0, 0, _aircraft.Pitch);
            transform.localPosition = _aircraft.Altitude * Vector3.up;
            transform.localPosition += _aircraft.TraveledDistance * Vector3.right;

            print($"{_aircraft.Pitch} / {_aircraft.Altitude} / {_aircraft.TraveledDistance}");
        }
    }
}