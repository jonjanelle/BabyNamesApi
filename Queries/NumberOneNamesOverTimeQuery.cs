using BabyNamesApi.Data;
using BabyNamesApi.Interfaces;
using BabyNamesApi.Models;
using System.Collections.Generic;

namespace BabyNamesApi.Queries
{
    public class NumberOneNameOverTimeQuery : IQuery<NumberOneNameOverTime>
    {

        private NumberOneNamesOverTimeRepository _repository { get; set; }
        private string _sex { get; set; }

        public NumberOneNameOverTimeQuery(string sex)
        {
            _repository = new NumberOneNamesOverTimeRepository();
            _sex = sex?.Trim()?.ToUpper();
        }

        public IEnumerable<NumberOneNameOverTime> Execute()
        {
            return _repository.Get(_sex);
        }
    }
}
