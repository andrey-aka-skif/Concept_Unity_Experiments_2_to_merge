using System;
using UnityEngine;

namespace E09_TestTask
{
    public class EnemySpawner : Pool<Entity>
    {
        private float _elapsedTime;

        public override Entity Prefab => _settings.EnemyPrefab;
        public virtual float SpawnTimeout => _settings.EntitySpawnTimeout;

        private void Update()
        {
            if (_elapsedTime >= SpawnTimeout)
            {
                CreateEnemy();
                _elapsedTime = 0;
            }

            _elapsedTime += Time.deltaTime;
        }

        private void CreateEnemy()
        {
            Entity entity = GetElement();
            entity.Activate();
            entity.Died += OnEntityDied;
        }

        private void OnEntityDied(Entity entity)
        {
            entity.Died -= OnEntityDied;
            ReturnElement(entity);
        }
    }
}