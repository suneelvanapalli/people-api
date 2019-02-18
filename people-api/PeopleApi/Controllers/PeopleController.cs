using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleApi.Models;
using PeopleApi.Services;

namespace PeopleApi.Controllers
{
    [Route("api")]
    public class PeopleController : Controller
    {
        readonly IPeopleService _peopleService; 
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        
        [HttpGet("pets/{petType}")]
        public async Task<Dictionary<string,List<string>>> Get(string petType)
        {
            return await _peopleService.GetPetsByCategory(petType);
        }

    }
}
