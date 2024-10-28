using System;

namespace E14_Events
{
    public interface IActivated
    {
        event Action<Action> ActionWithCallback;
    }
}
