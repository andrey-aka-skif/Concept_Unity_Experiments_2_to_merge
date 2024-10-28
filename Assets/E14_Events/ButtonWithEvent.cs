using System;
using UnityEngine;

namespace E14_Events
{
    public class ButtonWithEvent : MonoBehaviour, IActivated
    {
        public event Action<Action> ActionWithCallback;

        private void Start()
        {
            ActionWithCallback?.Invoke(CompleteHandler);
        }

        private void CompleteHandler()
        {
            Debug.Log("CompleteHandler");
        }
    }
}
