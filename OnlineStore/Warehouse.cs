using System;
using System.Collections.Generic;
using OnlineStore.Interfaces;

namespace OnlineStore
{
    public class Warehouse : IWarehouseRemovable
    {
        private readonly Dictionary<Product, int> _products;

        public Warehouse() =>
            _products = new Dictionary<Product, int>();

        public void Delive(Product good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(count.ToString());

            if (_products.ContainsKey(good))
                _products[good] += count;
            else
                _products.Add(good, count);
        }

        public bool Contains(Product good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(count.ToString());

            if (_products.ContainsKey(good))
                return _products[good] >= count;

            return false;
        }

        public void RemoveAmount(IReadOnlyDictionary<Product, int> goods)
        {
            if (goods == null)
                throw new ArgumentNullException(nameof(goods));

            foreach (KeyValuePair<Product, int> pair in goods)
            {
                if (Contains(pair.Key, pair.Value) == false)
                {
                    throw new InvalidOperationException();
                }

                _products[pair.Key] -= pair.Value;

                if (_products[pair.Key] == 0)
                {
                    _products.Remove(pair.Key);
                }
            }
        }
    }
}
