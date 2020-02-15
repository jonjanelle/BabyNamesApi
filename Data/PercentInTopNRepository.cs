using BabyNamesApi.Interfaces;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BabyNamesApi.Data
{
    public class PercentInTopNKeyBuilder
    {
        private int _n { get; set; }
        private string _sex { get; set; }

        public PercentInTopNKeyBuilder(int n, string sex)
        {
            _n = n;
            _sex = sex;
        }

        public string Key()
        {
            return $"{_n}_{_sex}";
        }

    }

    internal sealed class PercentInTopNRepository : IRepository<string, PercentInTopN>
    {
        private static readonly IDictionary<string, IEnumerable<PercentInTopN>> _babyNamesLookup;
        
        static PercentInTopNRepository()
        {
            _babyNamesLookup = new Dictionary<string, IEnumerable<PercentInTopN>>();
            GetData();
        }

        private static void GetData()
        {
            var baseDir = Path.Combine(Environment.CurrentDirectory, $@"Data\PercentInTopNByYear\");
            var files = Directory.GetFiles(baseDir);

            foreach (var file in files)
            {

                //var fileNameComponents = file.Split('\\').Last().Split('.').First().Split('_');
                //var lines = File.ReadAllLines(file);

                ////1880 22429 90994 24.648877947996574
                //lines.Select(line =>
                //{
                //    var lineComponents = line.Split(' ');
                //    return new PercentInTopN
                //    {
                //        Sex = fileNameComponents[]
                //        Year = Int32.Parse(lineComponents[0]),
                //    }
                //});

                //var stop = true;
            }
               

 
        }

        public IEnumerable<PercentInTopN> All()
        {
            return Enumerable.Empty<PercentInTopN>();
        }

        public IEnumerable<PercentInTopN> Get(string key)
        {
            if (_babyNamesLookup.ContainsKey(key))
                return _babyNamesLookup[key];

            return Enumerable.Empty<PercentInTopN>();
        }
    }
}
