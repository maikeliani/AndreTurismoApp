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

        /*  [HttpDelete(Name = "DeleteCity")]
          public bool Delete(int id)
          {
              return cityService.Delete(id);
          }

          [HttpPut(Name = "UpdateCity")]
          public bool Update(City city)
          {
              return cityService.Update(city);
          }*/
    }
}
