using System;

namespace OnlineStore
{
    public class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse) =>
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));

        public Cart Cart() =>
            new Cart(_warehouse);
    }
}
