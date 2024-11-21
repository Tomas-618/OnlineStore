using System;

namespace OnlineStore
{
    public class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse) =>
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));

        public Cart CreateCart() =>
            new Cart(_warehouse);
    }
}
