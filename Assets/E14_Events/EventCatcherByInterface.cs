using ExtendedAttributes;
using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace E14_Events
{
    public class EventCatcherByInterface : MonoBehaviour
    {
        [RequireInterface(typeof(IActivated))]
        public Object simpleExample;

        [SerializeField, RequireInterface(typeof(IActivated))]
        private Object _activated;
        private IActivated Activated => _activated as IActivated;

        private void Awake()
        {
            Activated.ActionWithCallback += OnEventRise;
        }

        private void OnEventRise(Action action)
        {
            StartCoroutine(Countdown(action));
        }

        IEnumerator Countdown(Action action)
        {
            yield return new WaitForSeconds(10);

            action?.Invoke();
        }
    }
}
