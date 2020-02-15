using BabyNamesApi.Data;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BabyNamesApi.DataScripts
{
    public class NumberOneOverTimeGenerator
    {
        private YearBabyNameRepository _repository { get; set; }
        private IEnumerable<string> _sexFilters = new List<string> { "M", "F" };

        public NumberOneOverTimeGenerator()
        {
            _repository = new YearBabyNameRepository();
        }


        public void Generate()
        {
            var baseDir = Path.Combine(Environment.CurrentDirectory, $@"Data\NumberOneNamesOverTime\");

            foreach (var sexFilter in _sexFilters)
            {
                var numberOneNamesOverTime = new List<NumberOneNameOverTime>();
                var processedNames = new Dictionary<string, bool>();
                var topNames = new List<string>();

                for (var year = YearBabyNameRepository.MinYear; year <= YearBabyNameRepository.MaxYear; year++)
                    topNames.Add(_repository.Get(year).Where(ybn => ybn.Sex == sexFilter).OrderByDescending(ybn => ybn.Count).First().Name);

                foreach (var topName in topNames)
                {
                    if (processedNames.ContainsKey(topName))
                        continue;
                    processedNames[topName] = true;

                    var lines = _repository.All()
                   .Where(name => name.Name == topName && name.Sex == sexFilter)
                   .OrderBy(name => name.Year)
                   .Select(name =>
                   {
                       double totalCount = _repository.Get(name.Year).Where(n => n.Sex == sexFilter).Select(n => n.Count).Sum();
                       Console.WriteLine(totalCount);
                       return $"{name.Name} {name.Sex} {name.Year} {name.Count} {((double)name.Count) / totalCount * 100.0}";
                   });
                    
                   File.WriteAllLines(@$"{baseDir}{topName}.txt", lines);
                }   
            }

        }

    }
}
