using System.Collections.Generic;
using UnityEngine;

namespace E09_TestTask
{
    public abstract class Pool<T> : MonoBehaviour where T : Entity
    {
        [SerializeField] protected Settings _settings;

        protected readonly Queue<T> _pool = new Queue<T>();

        public abstract T Prefab { get; }

        protected void Start()
        {
            for (int i = 0; i < _settings.EntityPoolCapacity; i++)
            {
                _pool.Enqueue(CreateNewElement());
            }
        }

        public T GetElement()
        {
            if (_pool.Count < 1)
            {
                return CreateNewElement();
            }
            return _pool.Dequeue();
        }

        public void ReturnElement(T entity)
        {
            entity.Deactivate();
            _pool.Enqueue(entity);
        }

        private T CreateNewElement()
        {
            T item = Instantiate(Prefab, this.transform);
            item.Settings = _settings;
            item.Deactivate();
            return item;
        }
    }
}