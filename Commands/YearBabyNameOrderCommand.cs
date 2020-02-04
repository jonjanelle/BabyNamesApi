using BabyNamesApi.Interfaces;
using BabyNamesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Commands
{
    public class YearBabyNameOrderCommand
    {
        private static readonly string[] ValidOrderings = new string[] { "asc", "desc" };
        private static readonly string[] ValidFields = new string[] { "name", "count", "sex", "year" };
        private IEnumerable<YearBabyName> _babyNames;
        private readonly string[] _orderComponents;

        public YearBabyNameOrderCommand(IEnumerable<YearBabyName> babyNames, string orderString)
        {
            _babyNames = babyNames;
            _orderComponents = (orderString ?? string.Empty).Split(' ').Select(s => s.Trim().ToLower()).ToArray();
        }

        public IEnumerable<YearBabyName> Execute()
        {
            if (_orderComponents.Count() == 0 || _orderComponents.Count() % 2 != 0)
                return _babyNames;

            IOrderedEnumerable<YearBabyName> orderedNames = null;

            for (var i = 0; i < _orderComponents.Count() / 2; i++)
            {
                var field = _orderComponents[2 * i];
                var order = _orderComponents[2 * i + 1];

                if (ValidOrderings.Contains(order) && ValidFields.Contains(field))
                {
                    if (field == "name")
                    {
                        if (i == 0)
                            orderedNames = order == "asc" ? _babyNames.OrderBy(a => a.Name) : _babyNames.OrderByDescending(a => a.Name);
                        else
                            orderedNames = order == "asc" ? orderedNames.ThenBy(a => a.Name) : orderedNames.ThenByDescending(a => a.Name);
                    }
                    else if (field == "count")
                    {
                        if (i == 0)
                            orderedNames = order == "asc" ? _babyNames.OrderBy(a => a.Count) : _babyNames.OrderByDescending(a => a.Count);
                        else
                            orderedNames = order == "asc" ? orderedNames.ThenBy(a => a.Count) : orderedNames.ThenByDescending(a => a.Count);
                    }
                    else if (field == "sex")
                    {
                        if (i == 0)
                            orderedNames = order == "asc" ? _babyNames.OrderBy(a => a.Sex) : _babyNames.OrderByDescending(a => a.Sex);
                        else
                            orderedNames = order == "asc" ? orderedNames.ThenBy(a => a.Sex) : orderedNames.ThenByDescending(a => a.Sex);
                    }
                    else if (field == "year")
                    {
                        if (i == 0)
                            orderedNames = order == "asc" ? _babyNames.OrderBy(a => a.Year) : _babyNames.OrderByDescending(a => a.Year);
                        else
                            orderedNames = order == "asc" ? orderedNames.ThenBy(a => a.Year) : orderedNames.ThenByDescending(a => a.Year);
                    }
                }
            }

            return orderedNames;
        }
    }
}
