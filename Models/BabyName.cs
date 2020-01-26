using BabyNamesApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Models
{
    public class BabyName : IBabyName
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Count { get; set; }
    }
}
