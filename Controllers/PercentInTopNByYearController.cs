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
    public class PercentInTopNByYearController
    {
        private PercentInTopNRepository _repository { get; set; }


        public PercentInTopNByYearController()
        {
            _repository = new PercentInTopNRepository();
        }

        // GET: api/PercentInTopNByYear
        [HttpGet]
        public IEnumerable<PercentInTopN> Get(
            [FromQuery]string year,
            [FromQuery]string sex
        )
        {

            return Enumerable.Empty<PercentInTopN>();
        }
    }
}
