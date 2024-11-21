using System.Collections.Generic;

namespace OnlineStore.Interfaces
{
    public interface IWarehouseRemovable
    {
        void RemoveAmount(IReadOnlyDictionary<Product, int> goods);

        bool Contains(Product good, int count);
    }
}
