using BabyNamesApi.Data;
using BabyNamesApi.Interfaces;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Queries
{
    internal class TopNameByYearQuery : IQuery<TopYearName>
    {
        private string _sex { get; set; }
        private YearBabyNameRepository _yearBabyNameRepository { get; set; }

        public TopNameByYearQuery(string sex)
        {
            _sex = sex?.Trim()?.ToUpper();
            _yearBabyNameRepository = new YearBabyNameRepository();
        }

        public IEnumerable<TopYearName> Execute()
        {
            var topYearNames = new List<TopYearName>();

            for (int year = YearBabyNameRepository.MinYear; year <= YearBabyNameRepository.MaxYear; year++)
            {
                YearBabyName topName;
                if (_sex == null || _sex.Length == 0)
                    topName = _yearBabyNameRepository.Get(year).OrderByDescending(bn => bn.Count).First();
                else
                    topName = _yearBabyNameRepository.Get(year).Where(bn => bn.Sex == _sex).OrderByDescending(bn => bn.Count).First();

                topYearNames.Add(new TopYearName
                {
                    Year = topName.Year,
                    Name = topName.Name,
                    Count = topName.Count
                });
            }

            return topYearNames;
        }


    }
}
