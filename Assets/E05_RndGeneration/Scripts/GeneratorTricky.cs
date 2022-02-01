using System.Collections;
using UnityEngine;

namespace E05_RndGeneration
{
    public class GeneratorTricky : MonoBehaviour
    {
        [SerializeField] private GameObject _targetPrefab;

        [SerializeField] private float _minSpawnRadius = 1;
        [SerializeField] private float _maxSpawnRadius = 5;

        [SerializeField] private int _count = 50;

        private IRndPlaceProvider _placer;

        private void Start()
        {
            float targetDiameter = GetTargetDiameter(_targetPrefab);

            _placer = new RndPlaceProvider(targetDiameter, _minSpawnRadius, _maxSpawnRadius);

            PlaceRandom(_targetPrefab, (RndPlaceProvider)_placer, _count);
        }

        private void PlaceRandom(GameObject prefab, RndPlaceProvider foo, int count)
        {
            IEnumerator enumerator = foo.GetEnumerator();

            for (int i = 0; i < count && enumerator.MoveNext(); i++)
            {
                CreateTarget(prefab, (Vector2)enumerator.Current);
            }
        }

        private void CreateTarget(GameObject prefab, Vector2 position)
        {
            GameObject go = Instantiate(prefab);
            go.transform.parent = transform;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localPosition = new Vector3(position.x, 0, position.y);
        }

        private float GetTargetDiameter(GameObject target)
        {
            // TODO: определить размер целевого объекта
            return 1;
        }
    }
}