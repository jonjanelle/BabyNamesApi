using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Interfaces
{
    public interface IQuery<T>
    {
        public IEnumerable<T> Execute();
    }
}
