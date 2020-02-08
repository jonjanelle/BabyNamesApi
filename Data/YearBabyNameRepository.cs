using BabyNamesApi.Interfaces;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BabyNamesApi.Data
{
    public class YearBabyNameRepository : IRepository<int, YearBabyName>
    {
        public static readonly int MinYear = 1880;
        public static readonly int MaxYear = 2018;

        private static readonly IDictionary<int, IEnumerable<YearBabyName>> _babyNamesLookup;

        static YearBabyNameRepository()
        {
            _babyNamesLookup = new Dictionary<int, IEnumerable<YearBabyName>>();

            for (var year = MinYear; year <= MaxYear; year++)
                ReadFileData(year);
        }

        private static void ReadFileData(int year)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, $@"Data\NamesByYear\yob{year.ToString()}.txt");
            if (File.Exists(filePath))
            {
                _babyNamesLookup[year] = File.ReadAllLines(filePath).Select(row => {
                    var rowElements = row.Split(',');
                    return new YearBabyName
                    {
                        Name = rowElements[0].Trim(),
                        Sex = rowElements[1].Trim(),
                        Count = Int32.Parse(rowElements[2]),
                        Year = year
                    };
                });
            }
        }

        public IEnumerable<YearBabyName> All()
        {
            return _babyNamesLookup.SelectMany(bn => bn.Value);
        }

        public IEnumerable<TopYearName> TopOverTime(string sex)
        {
            sex = sex?.Trim()?.ToUpper();
            var topYearNames = new List<TopYearName>();
            
            for (int year = MinYear; year <= MaxYear; year++)
            {
               YearBabyName topName;
               if (sex == null)
                    topName = _babyNamesLookup[year].OrderByDescending(bn => bn.Count).First();
               else 
                    topName = _babyNamesLookup[year].Where(bn => bn.Sex == sex).OrderByDescending(bn => bn.Count).First();

               topYearNames.Add(new TopYearName
               {
                   Year = topName.Year,
                   Name = topName.Name,
                   Count = topName.Count
               });
            }

            return topYearNames;
        }

        public IEnumerable<YearBabyName> Get(int year)
        {
            if (_babyNamesLookup.ContainsKey(year))
                return _babyNamesLookup[year];

            return Enumerable.Empty<StateBabyName>();
        }
    }
}