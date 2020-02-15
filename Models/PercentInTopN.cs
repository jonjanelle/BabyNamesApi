using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Models
{
    public class PercentInTopN
    {
        public int N {get; set;}
        public int Year { get; set; }
        public int TotalTopN { get; set; }
        public int TotalOverall { get; set; }
        public double Percent { get; set; }
        public string Sex { get; set; }
    }
}
