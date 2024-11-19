using OnlineStore.Interfaces;

namespace OnlineStore
{
    public class Warehouse : BaseStorage, IWarehouseRemovable
    {
        public void Delive(Good good, int count) =>
            AddGood(good, count);
    }
}
