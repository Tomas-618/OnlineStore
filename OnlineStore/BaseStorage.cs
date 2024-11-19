using System;
using System.Collections.Generic;

namespace OnlineStore
{
    public abstract class BaseStorage
    {
        private readonly Dictionary<Good, int> _goods;

        protected BaseStorage() =>
            _goods = new Dictionary<Good, int>();

        protected IReadOnlyDictionary<Good, int> Goods => _goods;

        public void RemoveGoods(IReadOnlyDictionary<Good, int> goods)
        {
            if (goods == null)
                throw new ArgumentNullException(nameof(goods));

            foreach (KeyValuePair<Good, int> pair in goods)
            {
                if (IsContains(pair.Key, pair.Value) == false)
                {
                    throw new InvalidOperationException();
                }

                _goods[pair.Key] -= pair.Value;
            }
        }

        public bool IsContains(Good good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(count.ToString());

            if (Goods.ContainsKey(good))
                return Goods[good] >= count;

            return false;
        }

        protected void Clear() =>
            _goods.Clear();

        protected void AddGood(Good good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(count.ToString());

            if (_goods.ContainsKey(good))
                _goods[good] += count;
            else
                _goods.Add(good, count);
        }
    }
}
