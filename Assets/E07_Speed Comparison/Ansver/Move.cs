using UnityEngine;

namespace E07_SpeedComparison
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private Vector3 _vector = Vector3.left;

        private void Update()
        {
            transform.position += _vector * Time.deltaTime;
        }
    }
}