using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApi.Models
{
    public class PetByOwnerDTO
    {
        public  string Gender { get; set; }
        public List<string> Pets { get; set; }
    }
}
