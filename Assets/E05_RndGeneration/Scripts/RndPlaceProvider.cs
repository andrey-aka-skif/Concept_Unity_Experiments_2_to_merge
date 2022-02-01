using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E05_RndGeneration
{
    public class RndPlaceProvider : IEnumerable, IRndPlaceProvider
    {
        private readonly List<Vector2> _places = new List<Vector2>();

        public int Count => _places.Count;

        public RndPlaceProvider(float targetDiameter, float minSpawnRadius, float maxSpawnRadius)
        {
            _places = GetPlaces(targetDiameter, minSpawnRadius, maxSpawnRadius);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public RndEnum GetEnumerator()
        {
            return new RndEnum(_places);
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
    }
}