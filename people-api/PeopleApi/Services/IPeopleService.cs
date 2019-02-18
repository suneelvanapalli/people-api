using PeopleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApi.Services
{
    public interface IPeopleService
    {
        Task<List<People>> GetPeopleDetails();
        Task<Dictionary<string, List<string>>> GetPetsByCategory(string petType);
    }
}
