using UnityEngine;

namespace E09_TestTask
{
    [RequireComponent(typeof(Entity))]
    public class EntityMover : MonoBehaviour
    {
        protected Settings _settings;

        protected Entity _entity;
        protected float _flySpeed;

        protected float _leftLimit;

        protected void Start()
        {
            _entity = GetComponent<Entity>();
            _settings = _entity.Settings;

            _flySpeed = _settings.EntityFlySpeed;

            _leftLimit = _settings.EntityLeftLimit;
        }

        protected void Update()
        {
            Move();
        }

        protected void Move()
        {
            transform.Translate(_flySpeed * Time.deltaTime * Vector3.left);

            if (IsWentAbroadHorizontal())
            {
                _entity.Die();
            }
        }

        protected bool IsWentAbroadHorizontal()
        {
            return transform.position.x < _leftLimit;
        }
    }
}