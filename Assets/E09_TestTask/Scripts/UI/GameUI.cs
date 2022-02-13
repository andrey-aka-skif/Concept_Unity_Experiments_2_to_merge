using UnityEngine;

namespace E09_TestTask.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Window _endGameView;
        [SerializeField] private GameController _gameController;

        private void Start()
        {
            HideWindow(_endGameView);
        }

        private void ShowWindow(Window window)
        {
            window.gameObject.SetActive(true);
        }

        private void HideWindow(Window window)
        {
            window.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _gameController.GameEnded += OnGameEnded;
        }

        private void OnDisable()
        {
            _gameController.GameEnded -= OnGameEnded;
        }

        private void OnGameEnded()
        {
            ShowWindow(_endGameView);
        }
    }
}