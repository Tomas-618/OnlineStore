using System;
using System.Collections.Generic;
using OnlineStore.Interfaces;

namespace OnlineStore
{
    public class Cart : BaseStorage
    {
        private readonly IWarehouseRemovable _warehouse;

        public Cart(IWarehouseRemovable warehouse) =>
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));

        public void Add(Good good, int count)
        {
            if (_warehouse.IsContains(good, count) == false)
                throw new InvalidOperationException();

            AddGood(good, count);
        }

        public Order Order()
        {
            _warehouse.RemoveGoods(Goods);
            Clear();

            return new Order();
        }
    }
}
