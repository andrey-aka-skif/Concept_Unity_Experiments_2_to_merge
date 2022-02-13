using UnityEngine;
using UnityEngine.UI;

namespace E09_TestTask.UI
{
    [RequireComponent(typeof(Text))]
    public class HudHpDisplay : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            _player.HealthChenged += OnPlayerHealthChenged;
        }

        private void OnDisable()
        {
            _player.HealthChenged -= OnPlayerHealthChenged;
        }

        private void OnPlayerHealthChenged(int health)
        {
            _text.text = $"{health}";
        }
    }
}