using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Models
{
    public class NumberOneNameOverTime
    {
        public string Name { get; set; }
        public IEnumerable<NameCountForYear> NameCountsForYear { get; set; }
    }
}
