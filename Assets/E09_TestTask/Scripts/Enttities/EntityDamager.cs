using UnityEngine;

namespace E09_TestTask
{
    [RequireComponent(typeof(Entity))]
    public class EntityDamager : MonoBehaviour
    {
        protected Settings _settings;

        private Entity _entity;
        private int _damage;

        private void Start()
        {
            _entity = GetComponent<Entity>();
            _settings = _entity.Settings;
            _damage = _settings.EnemyDamage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                player.ApplyDamage(_damage);
                _entity.Die();
            }
        }
    }
}