using BabyNamesApi.Data;
using BabyNamesApi.DataScripts;
using BabyNamesApi.Models;
using BabyNamesApi.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyNamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameOverTimeController : ControllerBase
    {
        // GET: api/TopByYear
        [HttpGet]
        public IEnumerable<string> Get(
            [FromQuery]string name,
            [FromQuery]string sex
        )
        {
            new NameOverTimeGenerator().Generate();
            return new List<string> { "" };
        }


    }
}
