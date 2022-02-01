using UnityEngine;

namespace E06_Timed
{
    public class Timer
    {
        private const float DEFAULT_TIMEOUT = 0.1f;
        private readonly float _timeout;
        private float _lastTime;

        public Timer(float timeout = DEFAULT_TIMEOUT)
        {
            _timeout = timeout;
        }

        public void Drop()
        {
            _lastTime = Time.time;
        }

        public bool Dropped
        {
            get
            {
                if(Time.time - _lastTime >= _timeout)
                {
                    _lastTime = Time.time;
                    return true;
                }
                return false;
            }
        }
    }
}