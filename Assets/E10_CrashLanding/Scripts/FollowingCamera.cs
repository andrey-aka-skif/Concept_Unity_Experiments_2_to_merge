using UnityEngine;

namespace E10_CrashLanding
{
    public class FollowingCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _oldTargetPosition;

        private void Update()
        {
            transform.position += _target.position - _oldTargetPosition;
            transform.LookAt(_target);
            _oldTargetPosition = _target.position;
        }
    }
}