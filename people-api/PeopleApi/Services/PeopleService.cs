using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PeopleApi.Common;
using PeopleApi.Models;

namespace PeopleApi.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration; 
        public PeopleService(IHttpClientFactory clientFactory, IOptions<ApplicationConfiguration> applicationConfiguration)
        {
            _clientFactory = clientFactory;
            _applicationConfiguration = applicationConfiguration;
        }

        /// <summary>
        /// Invokes People api to get the people details
        /// </summary>
        /// <returns></returns>
        public async Task<List<People>> GetPeopleDetails()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _applicationConfiguration.Value.PeopleApiUrl);


            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            var peopleList = default(List<People>);
            if (response.IsSuccessStatusCode)
            {
                peopleList = await response.Content.ReadAsAsync<List<People>>();
            }
            else
            {
                //throw error
            }

            return peopleList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="petType"></param>
        /// <returns></returns>
        public async Task<List<PetByOwnerDTO>> GetPetsByCategory(string petType)
        {
            var peopleList = await this.GetPeopleDetails();
            var petOwnerListDTO = new List<PetByOwnerDTO>();

            foreach (var people in peopleList)
            {
                var petOwner = petOwnerListDTO.Find(p => p.Gender == people.Gender);                 
                if (petOwner == null)
                {
                    petOwner = new PetByOwnerDTO() { Gender = people.Gender, Pets = new List<string>() };
                    petOwnerListDTO.Add(petOwner);
                }

                if (people.Pets != null && people.Pets.Count > 0)
                    petOwner.Pets.AddRange(people.Pets.Where(p => p.Type.ToLower() == petType.Trim().ToLower()).Select(p => p.Name));
            }

            foreach(var people in petOwnerListDTO)
            {
                people.Pets.Sort();
            }

            return petOwnerListDTO;
        }
    }
}
