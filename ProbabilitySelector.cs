using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Utilities
{
    public class ProbabilitySelector
    {
        private readonly Random _random;
        private readonly List<(object, float)> _list;

        public ProbabilitySelector()
        {
            _random = new Random((int)DateTime.Now.Ticks);
            _list = new List<(object, float)>();
        }

        public void Add(object item, float probability)
        {
            _list.Add((item,probability));
        }
    
        /// <summary>
        /// Selects an item based on objects and probabilities provided
        /// </summary>
        /// <returns>Random selected item</returns>
        public object Execute()
        {
            if (_list.Count == 0) return null;

            float total = 0;
            foreach (var item in _list) total += item.Item2;

            if (total != 1)
            {
                Debug.Log("Probabilities don't add up to 1, scaling probabilities...");
                for (int i = 0; i < _list.Count; i++)
                {
                    _list[i] = new ValueTuple<object, float>(_list[i].Item1, _list[i].Item2 / total);
                }
            }

            float value = (float)_random.NextDouble();

            for (int i = 0; i < _list.Count; i++)
            {
                if (value < _list[i].Item2)
                {
                    return _list[i].Item1;
                }

                value -= _list[i].Item2;
            }

            return null;
        }
    
    
    
    
    
    
        /// <summary>
        /// Selects an item based on objects and probabilities provided
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Random selected item</returns>
        public static object Select(List<(object,float)> items)
        {
            float total = 0;
            foreach ((object,float) item in items)
            {
                total += item.Item2;
            }

            if (total != 1)
            {
                Debug.Log("Probabilities don't add up to 1, scaling probabilities...");
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ValueTuple<object, float>(items[i].Item1, items[i].Item2 / total);
                }
            }

            float value = UnityEngine.Random.Range(0,1f);

            for (int i = 0; i < items.Count; i++)
            {
                if (value < items[i].Item2)
                {
                    return items[i].Item1;
                }

                value -= items[i].Item2;
            }

            return null;
        }
    }
}

