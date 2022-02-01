using System;
using System.Collections.Generic;
using UnityEngine;

namespace E05_RndGeneration
{
    public class GeneratorSimple : MonoBehaviour
    {
        [SerializeField] private GameObject _targetPrefab;

        [SerializeField] private float _minSpawnRadius = 1;
        [SerializeField] private float _maxSpawnRadius = 5;

        [SerializeField] private int _count = 50;

        private void Start()
        {
            float targetDiameter = GetTargetDiameter(_targetPrefab);

            List<Vector2> places = GetPlaces(targetDiameter, _minSpawnRadius, _maxSpawnRadius);

            //PlaceAll(_targetPrefab, places);
            PlaceRandom(_targetPrefab, places, _count);
        }

        private List<Vector2> GetPlaces(float targetDiameter, float minSpawnRadius, float maxSpawnRadius)
        {
            List<Vector2> places = new List<Vector2>();

            double R = targetDiameter < minSpawnRadius ? minSpawnRadius : targetDiameter;
            double C;
            int targetsCountInCircle;
            double angleStep;

            double x;
            double y;

            int circleCount = (int)((maxSpawnRadius - minSpawnRadius) / targetDiameter);

            for (int i = 0; i < circleCount; i++)
            {
                R = i > 0 ? R + targetDiameter : R;
                C = 2 * Math.PI * R;
                targetsCountInCircle = (int)(C / targetDiameter);
                angleStep = 360.0d / targetsCountInCircle;

                for (int j = 0; j < targetsCountInCircle; j++)
                {
                    x = R * Math.Cos(j * angleStep * Math.PI / 180);
                    y = R * Math.Sin(j * angleStep * Math.PI / 180);

                    places.Add(new Vector2((float)x, (float)y));
                }
            }

            return places;
        }

        private void PlaceAll(GameObject prefab, List<Vector2> places)
        {
            foreach (Vector2 item in places)
            {
                CreateTarget(prefab, item);
            }
        }

        private void PlaceRandom(GameObject prefab, List<Vector2> places, int count)
        {
            System.Random rnd = new System.Random();
            int nextIndex;
            Vector2 nextPosition;

            int max = count < places.Count ? count : places.Count;

            for (int i = 0; i < max; i++)
            {
                nextIndex = rnd.Next(places.Count);
                nextPosition = places[nextIndex];
                CreateTarget(prefab, nextPosition);
                places.RemoveAt(nextIndex);
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