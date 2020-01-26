using System;
using System.Collections.Generic;
using System.Linq;
using BabyNamesApi.Commands;
using BabyNamesApi.Data;
using BabyNamesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabyNamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateBabyNamesController : ControllerBase
    {
        // GET: api/YearBabyNames
        [HttpGet]
        public IEnumerable<StateBabyName> Get(
            [FromQuery]string state,
            [FromQuery]int? year,
            [FromQuery]string sex,
            [FromQuery]string name,
            [FromQuery]bool? exactNameMatch,
            [FromQuery]string orderBy,
            [FromQuery]int? top 
        )
        {
            List<StateBabyName> babyNames = new List<StateBabyName>();

            if (state != null && Enum.TryParse(state.Trim().ToUpper(), out StateCode stateCode))
                babyNames = new StateBabyNameRepository().Get(stateCode).ToList();
            else
                babyNames = new StateBabyNameRepository().All().ToList();

            if (year.HasValue)
                babyNames = babyNames.Where(bn => bn.Year == year).ToList();                    

            if (sex != null)
            {
                sex = sex.Trim().ToUpper();
                babyNames = babyNames.Where(bn => bn.Sex == sex).ToList();
            }

            if (name != null)
            {
                name = name.Trim().ToLower();
                if (exactNameMatch.HasValue)
                    babyNames = babyNames.Where(bn => bn.Name.ToLower() == name).ToList();
                else
                    babyNames = babyNames.Where(bn => bn.Name.ToLower().StartsWith(name)).ToList();
            }

            if (orderBy != null)
                babyNames = new StateBabyNameOrderCommand(babyNames, orderBy).Execute().ToList();

            if (top.HasValue && top.Value > 0)
                babyNames = babyNames.Take(top.Value).ToList();

            return babyNames;
        }
    }
}
