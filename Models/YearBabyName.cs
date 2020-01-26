using BabyNamesApi.Interfaces;

namespace BabyNamesApi.Models
{
    public class YearBabyName : IBabyName
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Sex { get; set; }
        public int Year { get; set; }
    }
}
