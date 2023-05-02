using System.Net;
using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private CityService _cityService;

        public CityController()
        {
            _cityService = new CityService();
        }


        [HttpGet(Name = "GetAllCities")]
        public  async Task<List<City>>GetAll()
        {
            return  await _cityService.GetCities();
        }


        [HttpPost(Name ="PostCity")]
        public async Task<City> PostCity(City city)
        {
            return await _cityService.PostCity(city);
        }

        [HttpGet("{id}", Name = "BuscaCityPorId")]
        public async Task<City> GetCity(int id)
        {
            return await _cityService.GetCity(id);
        }


        [HttpDelete("{id}")]
        public async Task<City> Delete(int id)
        {
            return await _cityService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<City> PutCity(int id, City c)
        {
            return await _cityService.PutCity(id, c);
        }
        /*
                [HttpPut]
                public async Task<HttpStatusCode> PutCity(City city)
                {
                    return await _cityService.PutCity(city);
                }*/
    }
}
