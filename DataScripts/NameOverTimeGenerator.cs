using BabyNamesApi.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BabyNamesApi.DataScripts
{
    public class NameOverTimeGenerator
    {
        private YearBabyNameRepository _repository { get; set; }
        private IEnumerable<string> _sexFilters = new List<string> { "M", "F" };

        public NameOverTimeGenerator()
        {
            _repository = new YearBabyNameRepository();
        }

        public void Generate()
        {
            var allData = _repository.All();
            var baseDir = Path.Combine(Environment.CurrentDirectory, $@"Data\NameOverTime\");
         
            foreach (var sexFilter in _sexFilters)
            {
                var processedNames = new Dictionary<string, bool>();
                var currentData = allData.Where(ybn => ybn.Sex == sexFilter);
                var outputData = new List<string>();

                foreach (var name in currentData)
                {
                    if (processedNames.ContainsKey(name.Name))
                        continue;
                    processedNames[name.Name] = true;
                    
                    var nameData = currentData.Where(ybn => ybn.Name == name.Name);
                    var yearCountLookup = new Dictionary<int, int>();
                    foreach (var nd in nameData)
                        yearCountLookup[nd.Year] = nd.Count;

                    var outputStr = new StringBuilder();
                    outputStr.Append(name.Name);

                    for (var year = YearBabyNameRepository.MinYear; year <= YearBabyNameRepository.MaxYear; year++)
                    {
                        var count = yearCountLookup.ContainsKey(year) ? yearCountLookup[year] : 0;
                        outputStr.Append($" {count}");
                    }
                   
                    outputData.Add(outputStr.ToString());
                }

                File.WriteAllLines(@$"{baseDir}{sexFilter}.txt", outputData);
            }

        
        }
    }
}
