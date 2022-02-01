using UnityEngine;

namespace E04_Awaker
{
    public class Awaker : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Start");
        }

        void Awake()
        {
            Debug.Log("Awake");
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable");
            Debug.Log(gameObject.activeSelf);
        }

        private void OnDisable()
        {
            Debug.Log("OnDisable");
            Debug.Log(gameObject.activeSelf);
        }
    }
}