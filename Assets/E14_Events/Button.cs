using System;
using UnityEngine;

namespace E14_Events
{
    public interface IFoo { }

    public class Button : AbstractEventSource, IFoo
    {
        private void Start()
        {
            TryRiseEvent(CompleteHandler);
        }

        private void CompleteHandler()
        {
            Debug.Log("CompleteHandler");
        }
    }

    public abstract class AbstractEventSource : MonoBehaviour
    {
        public event Action<Action> ActionWithCallback;

        protected void TryRiseEvent(Action action)
        {
            ActionWithCallback?.Invoke(action);
        }
    }
}
