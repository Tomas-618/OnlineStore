using System;

namespace OnlineStore
{
    public struct Order
    {
        public Order(string paylink) =>
            Paylink = paylink ?? throw new ArgumentNullException(nameof(paylink));

        public string Paylink { get; }
    }
}
