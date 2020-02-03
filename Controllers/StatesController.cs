using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyNamesApi.Models;
using BabyNamesApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BabyNamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        // GET: api/StateCodes
        [HttpGet]
        public IEnumerable<State> Get()
        {
            return EnumHelpers.GetValues<StateCode>().Select(sc => new State(sc));
        }
    }
}
