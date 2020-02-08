using BabyNamesApi.Interfaces;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BabyNamesApi.Data
{
    internal sealed class StateBabyNameRepository : IRepository<StateCode, StateBabyName>
    {
        private static readonly IDictionary<StateCode, IEnumerable<StateBabyName>> _babyNamesLookup;

        static StateBabyNameRepository()
        {
            _babyNamesLookup = new Dictionary<StateCode, IEnumerable<StateBabyName>>();
            var stateCodes = Enum.GetNames(typeof(StateCode));
            foreach (var stateCode in stateCodes)
            {
                ReadFileData(stateCode);
            }
        }

        private static void ReadFileData(string stateCode)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, $@"Data\NamesByState\{stateCode}.TXT");
            if (File.Exists(filePath))
            {
                Enum.TryParse(stateCode, out StateCode key);
                _babyNamesLookup[key] = File.ReadAllLines(filePath).Select(row => {
                    var rowElements = row.Split(',');
                    return new StateBabyName
                    {
                        State = rowElements[0].Trim(),
                        Sex = rowElements[1].Trim(),
                        Year = Int32.Parse(rowElements[2]),
                        Name = rowElements[3].Trim(),
                        Count = Int32.Parse(rowElements[4])
                    };
                });
            }
        }

        public IEnumerable<StateBabyName> All()
        {
            return _babyNamesLookup.SelectMany(bn => bn.Value);
        }

        public IEnumerable<StateBabyName> Get(StateCode state)
        {
            if (_babyNamesLookup.ContainsKey(state))
                return _babyNamesLookup[state];

            return Enumerable.Empty<StateBabyName>();
        }
    }
}
