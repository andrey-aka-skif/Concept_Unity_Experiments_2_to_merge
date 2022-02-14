using UnityEngine;

namespace E10_CrashLanding
{
    [RequireComponent(typeof(AircraftMover))]
    public class AircraftTouchInput : MonoBehaviour
    {
        private AircraftMover _mover;

        private void Start()
        {
            _mover = transform.GetComponent<AircraftMover>();
        }

        private void Update()
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _mover.TryMoveUp();
            }
        }
    }
}