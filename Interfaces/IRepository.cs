using System.Collections.Generic;

namespace BabyNamesApi.Interfaces
{
    public interface IRepository<K, V>
    {
        public IEnumerable<V> All();
        public IEnumerable<V> Get(K key);
    }
}
