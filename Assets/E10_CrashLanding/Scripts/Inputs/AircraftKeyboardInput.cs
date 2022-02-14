using UnityEngine;

namespace E10_CrashLanding
{
    [RequireComponent(typeof(Aircraft))]
    public class AircraftKeyboardInput : MonoBehaviour
    {
        [SerializeField] private KeyCode _upKey = KeyCode.Space;

        private Aircraft _aircraft;

        private void Start()
        {
            _aircraft = transform.GetComponent<Aircraft>();
        }

        private void Update()
        {
            if (Input.GetKey(_upKey))
            {
                _aircraft.Accelerate();
            }
        }
    }
}