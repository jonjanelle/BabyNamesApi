using System;
using System.Collections.Generic;
using System.Linq;
using BabyNamesApi.Commands;
using BabyNamesApi.Data;
using BabyNamesApi.Models;
using BabyNamesApi.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BabyNamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberOneNamesOverTimeController : ControllerBase
    {
        // GET: api/NumberOneNamesOverTime
        [HttpGet]
        public IEnumerable<NumberOneNameOverTime> Get([FromQuery]string sex)
        {
            return new NumberOneNameOverTimeQuery(sex).Execute();
        }
    }
}
