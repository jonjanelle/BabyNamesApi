using BabyNamesApi.Data;
using BabyNamesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopByYearController : ControllerBase
    {
        // GET: api/TopByYear
        [HttpGet]
        public IEnumerable<TopYearName> Get([FromQuery]string sex)
        {
            return new YearBabyNameRepository().TopOverTime(sex).ToList();
        }
    }
}
