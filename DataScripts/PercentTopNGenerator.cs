using BabyNamesApi.Data;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BabyNamesApi.DataScripts
{
    public class PercentTopNGenerator
    {
        private YearBabyNameRepository _repository { get; set; }
        private IEnumerable<int> _topCounts = new List<int> { 10, 25, 50, 100, 200, 300, 500, 1000 };
        private IEnumerable<string> _sexFilters = new List<string> { "M", "F" };

        public PercentTopNGenerator()
        {
            _repository = new YearBabyNameRepository();
        }

        public void Generate()
        {
            var baseDir = Path.Combine(Environment.CurrentDirectory, $@"Data\PercentInTopNByYear\");
            foreach (var topCount in _topCounts)
            {
                foreach (var sexFilter in _sexFilters)
                {
                    var percentTopN = new List<string>();
                    for (var year = YearBabyNameRepository.MinYear; year <= YearBabyNameRepository.MaxYear; year++)
                    {
                        var yearNames = _repository.Get(year)
                            .Where(yn => yn.Sex == sexFilter)
                            .Select(yn => yn.Count)
                            .OrderByDescending(yn => yn);

                        var topNCount = yearNames.Take(topCount).Sum();
                        var totalCount = yearNames.Sum();
                        percentTopN.Add($"{year} {topNCount} {totalCount} {((double)topNCount) / totalCount * 100.0}");
                    }
                    File.WriteAllLines(@$"{baseDir}{sexFilter}_{topCount}.txt", percentTopN);
                }

                GenerateCombined(topCount, baseDir);
            }
        }

        private void GenerateCombined(int topCount, string baseDir)
        {
            var percentTopN = new List<string>();
            for (var year = YearBabyNameRepository.MinYear; year <= YearBabyNameRepository.MaxYear; year++)
            {
                var yearNames = _repository.Get(year)
                    .Select(yn => yn.Count)
                    .OrderByDescending(yn => yn);

                var topNCount = yearNames.Take(topCount).Sum();
                var totalCount = yearNames.Sum();
                percentTopN.Add($"{year} {topNCount} {totalCount} {((double)topNCount) / totalCount * 100.0}");
            }
            File.WriteAllLines(@$"{baseDir}Combined_{topCount}.txt", percentTopN);
        }
    }
}
