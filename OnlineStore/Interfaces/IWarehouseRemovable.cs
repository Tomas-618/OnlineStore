using System.Collections.Generic;

namespace OnlineStore.Interfaces
{
    public interface IWarehouseRemovable
    {
        void RemoveGoods(IReadOnlyDictionary<Good, int> goods);

        bool IsContains(Good good, int count);
    }
}
