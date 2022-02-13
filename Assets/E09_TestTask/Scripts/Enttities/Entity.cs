using System;
using UnityEngine;

namespace E09_TestTask
{
    public class Entity : MonoBehaviour, IPoolable
    {
        public Settings Settings { get; set; }

        public event Action<Entity> Died;

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            gameObject.SetActive(false);
        }

        public void Die()
        {
            Died?.Invoke(this);
        }
    }
}