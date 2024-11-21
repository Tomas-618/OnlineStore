using System;
using System.Collections.Generic;
using OnlineStore.Interfaces;

namespace OnlineStore
{
    public class Cart
    {
        private readonly Dictionary<Product, int> _products;
        private readonly IWarehouseRemovable _warehouse;

        public Cart(IWarehouseRemovable warehouse)
        {
            _products = new Dictionary<Product, int>();
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
        }

        public Order CreateOrder()
        {
            _warehouse.RemoveAmount(_products);
            Clear();

            return new Order("просто какая - нибудь случайная строка.");
        }

        public void Add(Product good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(count.ToString());

            _products.TryGetValue(good, out int currentCount);

            if (_warehouse.Contains(good, currentCount + count) == false)
                throw new InvalidOperationException();

            if (_products.ContainsKey(good))
                _products[good] += count;
            else
                _products.Add(good, count);
        }

        private void Clear() =>
            _products.Clear();
    }
}
