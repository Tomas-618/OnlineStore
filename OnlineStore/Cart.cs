using System;
using OnlineStore.Interfaces;

namespace OnlineStore
{
    public class Cart : BaseStorage
    {
        private readonly IWarehouseRemovable _warehouse;

        public Cart(IWarehouseRemovable warehouse) =>
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));

        public Order CreateOrder()
        {
            _warehouse.RemoveAmount(Products);
            Clear();

            return new Order("просто какая - нибудь случайная строка.");
        }

        protected override void OnAdd(Product good, int count)
        {
            Products.TryGetValue(good, out int currentCount);

            if (_warehouse.Contains(good, currentCount + count) == false)
                throw new InvalidOperationException();
        }
    }
}
