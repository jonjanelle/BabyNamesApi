using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Shared
{
    public static class EnumHelpers
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
