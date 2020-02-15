using System.Collections.Generic;

namespace BabyNamesApi.Models
{
    public class NumberOneNameOverTime
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public IEnumerable<YearCount> YearCounts { get; set; }
    }
}
