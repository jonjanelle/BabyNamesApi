using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Interfaces
{
    public interface IOrderer<T>
    {
        public static readonly string OrderField;
        public IEnumerable<T> Order(IEnumerable<T> items, string ordering);
    }
}
