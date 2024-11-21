using System;
using System.Collections.Generic;

namespace OnlineStore
{
    public abstract class BaseStorage
    {
        private readonly Dictionary<Product, int> _products;

        protected BaseStorage() =>
            _products = new Dictionary<Product, int>();

        protected IReadOnlyDictionary<Product, int> Products => _products;

        public void Add(Product good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(count.ToString());

            OnAdd(good, count);

            if (_products.ContainsKey(good))
                _products[good] += count;
            else
                _products.Add(good, count);
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

        public bool Contains(Product good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(count.ToString());

            if (Products.ContainsKey(good))
                return Products[good] >= count;

            return false;
        }

        protected void Clear() =>
            _products.Clear();

        protected virtual void OnAdd(Product good, int count) { }
    }
}
