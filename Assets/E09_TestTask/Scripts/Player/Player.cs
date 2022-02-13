using System;
using UnityEngine;

namespace E09_TestTask
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Settings _settings;

        public event Action<int> HealthChenged;
        public event Action Died;

        public int Health { get; private set; }

        public int Score { get; private set; }

        private void Start()
        {
            Health = _settings.StartHealth;
            Score = 0;

            HealthChenged?.Invoke(Health);
        }

        public void ApplyDamage(int damage)
        {
            if (Health <= 0)
                return;

            Health -= damage;

            if (Health < 0)
                Health = 0;

            HealthChenged?.Invoke(Health);

            if (Health == 0)
                Die();
        }

        public void AddScore(int scoreValue = 1)
        {
            Score += scoreValue;
        }

        private void Die()
        {
            Died?.Invoke();
        }
    }
}