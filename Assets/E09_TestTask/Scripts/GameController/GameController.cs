using System;
using UnityEngine;

namespace E09_TestTask
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public event Action GameEnded;

        private void OnEnable()
        {
            _player.Died += OnPlayerDied;
        }

        private void OnDisable()
        {
            _player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            Time.timeScale = 0;
            GameEnded?.Invoke();
        }
    }
}