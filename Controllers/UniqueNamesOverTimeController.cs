using BabyNamesApi.Data;
using BabyNamesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BabyNamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniqueNamesOverTimeController
    {
        private YearBabyNameRepository _repository { get; set; }
        private string _sex { get; set; }


        public UniqueNamesOverTimeController()
        {
            _repository = new YearBabyNameRepository();
        }

        // GET: api/NumberOneNamesOverTime
        [HttpGet]
        public IEnumerable<YearCount> Get([FromQuery]string sex)
        {
            _sex = sex?.Trim()?.ToUpper();
            var yearCounts = new List<YearCount>();
            for (var year = YearBabyNameRepository.MinYear; year <= YearBabyNameRepository.MaxYear; year++)
            {
                yearCounts.Add(new YearCount
                {
                    Year = year,
                    Count = _repository.Get(year).Count()
                });
                
            }

            return yearCounts.OrderBy(yc => yc.Year);
        }
    }
}
