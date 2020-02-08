using BabyNamesApi.Data;
using BabyNamesApi.Interfaces;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Queries
{
    public class NumberOneNameOverTimeQuery : IQuery<NumberOneNameOverTime>
    {

        private YearBabyNameRepository _yearBabyNameRepository { get; set; }
        private string _sex { get; set; }

        public NumberOneNameOverTimeQuery(string sex)
        {
            _yearBabyNameRepository = new YearBabyNameRepository();
            _sex = sex;
        }

        public IEnumerable<NumberOneNameOverTime> Execute()
        {
            return Enumerable.Empty<NumberOneNameOverTime>();
        }
    }
}
