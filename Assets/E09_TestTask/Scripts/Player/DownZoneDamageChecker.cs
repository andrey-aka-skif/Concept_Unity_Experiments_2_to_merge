using UnityEngine;

namespace E09_TestTask
{
    [RequireComponent(typeof(Player))]
    public class DownZoneDamageChecker : MonoBehaviour
    {
        [SerializeField] private Settings _settings;

        private Player _player;
        private float _minHeight;
        private float _safeDistance;
        private float _damageTimeout;
        private int _onTimeDamage;
        private float _elapsedTime;

        private void Start()
        {
            _player = GetComponent<Player>();

            _minHeight = _settings.MinHeight;
            _safeDistance = _settings.SafeDistance;
            _damageTimeout = _settings.DamageTimeout;
            _onTimeDamage = _settings.OnTimeDamage;
            _elapsedTime = 0;
        }

        private void Update()
        {
            if (transform.position.y < _minHeight + _safeDistance)
            {
                _elapsedTime += Time.deltaTime;

                if (_elapsedTime >= _damageTimeout)
                {
                    _player.ApplyDamage(_onTimeDamage);
                    _elapsedTime = 0;
                }
            }
            else
            {
                _elapsedTime = 0;
            }
        }
    }
}