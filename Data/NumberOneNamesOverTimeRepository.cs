using BabyNamesApi.Interfaces;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BabyNamesApi.Data
{
    public class NumberOneNamesOverTimeRepository : IRepository<string, NumberOneNameOverTime>
    {
        public static readonly string Female = "F";
        public static readonly string Male = "M";

        private static readonly int MinYear = 1880;
        private static readonly int MaxYear = 2018;

        private static readonly IDictionary<string, ICollection<NumberOneNameOverTime>> _babyNamesLookup;

        static NumberOneNamesOverTimeRepository()
        {
            _babyNamesLookup = new Dictionary<string, ICollection<NumberOneNameOverTime>>();
            _babyNamesLookup[Female] = new List<NumberOneNameOverTime>();
            _babyNamesLookup[Male] = new List<NumberOneNameOverTime>();
            ReadFileData();
        }

        private static void ReadFileData()
        {
            var baseDir = Path.Combine(Environment.CurrentDirectory, $@"Data\NumberOneNamesOverTime\");
            var files = Directory.GetFiles(baseDir);
            foreach (var file in files)
            {
                var newName = new NumberOneNameOverTime();
                var yearCounts = new List<YearCount>();

                var lines = File.ReadAllLines(file);
                var yearsCovered = new List<int>();
                foreach (var line in lines)
                {
                    var rowElements = line.Split(' ');
                    newName.Name = rowElements[0];
                    newName.Sex = rowElements[1];
                    int year = Int32.Parse(rowElements[2]);
                    yearCounts.Add(new YearCount
                    {
                        Year = year,
                        Count = Int32.Parse(rowElements[3]),
                        PercentOfTotal = Double.Parse(rowElements[4])
                    });

                    yearsCovered.Add(year);
                }

                for (var year = MinYear; year <= MaxYear; year++)
                {
                    if (!yearsCovered.Contains(year))
                    {
                        yearCounts.Add(new YearCount
                        {
                            Year = year,
                            Count = 0,
                            PercentOfTotal = 0.0
                        });
                    }
                }

                newName.YearCounts = yearCounts.OrderBy(yc => yc.Year);
                _babyNamesLookup[newName.Sex].Add(newName);
            }
        }

        public IEnumerable<NumberOneNameOverTime> All()
        {
            return _babyNamesLookup.SelectMany(bn => bn.Value);
        }


        public IEnumerable<NumberOneNameOverTime> Get(string sex)
        {
            if (sex != null && _babyNamesLookup.ContainsKey(sex))
                return _babyNamesLookup[sex];

            return Enumerable.Empty<NumberOneNameOverTime>();
        }
    }
}
