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
        private CityService cityService;
        public CityController()
        {
            cityService = new CityService();
        }

        [HttpPost(Name = "InsertCity")]
        public int Insert(City city)
        {
            return cityService.Insert(city);
        }

        [HttpGet(Name = "GetAllCities")]
        public List<City> GetAll()
        {
            return cityService.GetAll();
        }

        [HttpDelete(Name = "DeleteCity")]
        public bool Delete(int id)
        {
            return cityService.Delete(id);
        }

        [HttpPut(Name = "UpdateCity")]
        public bool Update(City city)
        {
            return cityService.Update(city);
        }
    }
}
