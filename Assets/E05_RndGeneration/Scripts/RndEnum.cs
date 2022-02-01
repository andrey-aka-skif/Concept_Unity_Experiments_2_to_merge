using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace E05_RndGeneration
{
    public class RndEnum : IEnumerator
    {
        private readonly List<Vector2> _places;
        private List<Vector2> _placesWork = new List<Vector2>();
        private int _index = -1;

        private readonly System.Random _rnd = new System.Random();

        public RndEnum(List<Vector2> places)
        {
            _places = places;
            Reset();
        }

        public bool MoveNext()
        {
            if (_placesWork.Count > 0)
            {
                _index = _rnd.Next(_placesWork.Count);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _index = -1;
            _placesWork = _places.ToList();
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Vector2 Current
        {
            get
            {
                try
                {
                    Vector2 position = _placesWork[_index];
                    _placesWork.RemoveAt(_index);
                    return position;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}