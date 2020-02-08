using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Models
{
    public class NameCountForYear
    { 
        public string Name { get; set; }
        public int Count { get; set; }
        public int Year { get; set; }
    }
}
