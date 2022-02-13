using UnityEngine;
using UnityEngine.UI;

namespace E09_TestTask.UI
{
    [RequireComponent(typeof(Text))]
    public class HudScoreDisplay : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }
    }
}