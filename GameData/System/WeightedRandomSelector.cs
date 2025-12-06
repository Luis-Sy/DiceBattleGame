using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.System
{
    public class WeightedRandomSelector<T> // a class used to select items based on assigned weights
    {
        private readonly List<(T Item, double Weight)> _items;
        private readonly Random _random;
        private double _totalWeight;

        public WeightedRandomSelector()
        {
            _items = new List<(T Item, double Weight)>();
            _random = new Random();
            _totalWeight = 0;
        }
        // seeded constructor
        public WeightedRandomSelector(int seed)
        {
            _items = new List<(T Item, double Weight)>();
            _random = new Random(seed);
            _totalWeight = 0;
        }

        public void AddItem(T item, double weight)
        {
            if (weight < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight cannot be negative.");
            }
            _items.Add((item, weight));
            _totalWeight += weight;
        }

        public T GetRandomItem()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("No items added to the selector.");
            }

            double randomNumber = _random.NextDouble() * _totalWeight;
            double cumulativeWeight = 0;

            foreach (var itemData in _items)
            {
                cumulativeWeight += itemData.Weight;
                if (randomNumber < cumulativeWeight)
                {
                    return itemData.Item;
                }
            }

            // This should ideally not be reached if totalWeight is calculated correctly
            // and randomNumber is within the correct range.
            return _items.Last().Item;
        }
    }
}
