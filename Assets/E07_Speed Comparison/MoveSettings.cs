using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E07_SpeedComparison
{
    [CreateAssetMenu]
    public class MoveSettings : ScriptableObject
    {
        public float Step = 0.1f;
        public float Timeout = 0.1f;

        public float Speed => Step / Timeout;
    }
}