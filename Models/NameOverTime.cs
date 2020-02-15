using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Models
{
    public class NameOverTime
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public IEnumerable<YearCount> yearCounts;
    }
}
