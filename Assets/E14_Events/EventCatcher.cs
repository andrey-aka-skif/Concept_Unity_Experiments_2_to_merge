using System;
using System.Collections;
using UnityEngine;

namespace E14_Events
{
    public class EventCatcher : MonoBehaviour
    {
        [SerializeField] private AbstractEventSource _eventSource;

        private void Awake()
        {
            _eventSource.ActionWithCallback += OnEventRise;
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
