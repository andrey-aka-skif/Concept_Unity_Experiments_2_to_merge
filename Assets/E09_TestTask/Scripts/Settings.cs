using UnityEngine;

namespace E09_TestTask
{
    public class Settings : MonoBehaviour
    {
        #region Player
        [Header("Player")]
        [SerializeField] private int _startHealth;
        [SerializeField] private float _verticalSpeed;
        public int StartHealth => _startHealth;
        public float VerticalSpeed => _verticalSpeed;
        #endregion

        #region PlayerDownDamage
        [Header("PlayerDownDamage")]
        [SerializeField] private float _safeDistance;
        [SerializeField] private float _damageTimeout;
        [SerializeField] private int _onTimeDamage;
        public float SafeDistance => _safeDistance;
        public float DamageTimeout => _damageTimeout;
        public int OnTimeDamage => _onTimeDamage;
        #endregion


        #region All
        [Header("All")]
        [SerializeField] private float _maxHeight;
        [SerializeField] private float _minHeight;
        public float MinHeight => _minHeight;
        public float MaxHeight => _maxHeight;

        #endregion

        #region Entity
        [Header("Entity")]
        [SerializeField] private float _entityFlySpeed;
        [SerializeField] private float _entityTopLimit;
        [SerializeField] private float _entityBottomLimit;
        [SerializeField] private float _entityLeftLimit;
        [SerializeField] private float _entityRightLimit;
        [SerializeField] private int _entityPoolCapacity;
        [SerializeField] private float _entitySpawnTimeout;
        public float EntityFlySpeed => _entityFlySpeed;
        public float EntityTopLimit => _entityTopLimit;
        public float EntityBottomLimit => _entityBottomLimit;
        public float EntityLeftLimit => _entityLeftLimit;
        public float EntityRightLimit => _entityRightLimit;
        public int EntityPoolCapacity => _entityPoolCapacity;
        public float EntitySpawnTimeout => _entitySpawnTimeout;
        #endregion

        #region Enemy
        [Header("Enemy")]
        [SerializeField] private int _enemyDamage;
        [SerializeField] private float _enemyVerticalSpeed;
        [SerializeField] private Entity _enemyPrefab;
        public int EnemyDamage => _enemyDamage;
        public float EnemyVerticalSpeed => _enemyVerticalSpeed;
        public Entity EnemyPrefab => _enemyPrefab;
        #endregion

        #region BallonEnemy
        [Header("BallonEnemy")]
        [SerializeField] private Entity _balloonEnemyPrefab;
        public Entity BalloonEnemyPrefab => _balloonEnemyPrefab;
        #endregion
    }
}