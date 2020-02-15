using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Models
{
    public class RankedYearName : YearBabyName
    {
        public int Rank { get; set; }
    }
}
