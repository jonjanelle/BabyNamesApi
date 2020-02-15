using System.Collections.Generic;

namespace BabyNamesApi.Interfaces
{
    public interface IRepository<TKey, TValue>
    {
        public IEnumerable<TValue> All();
        public IEnumerable<TValue> Get(TKey key);
    }
}
