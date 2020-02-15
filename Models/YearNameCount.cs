using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Models
{
    public class YearNameCount
    {
        public int Year { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
