
using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressService addressService;
        private CityService cityService;
        public AddressController()
        {
            addressService = new AddressService();
            cityService = new CityService();
        }

        [HttpPost(Name = "InsertAddress")]
        public int Insert(Address address)
        {
            var idCity = cityService.Insert(address.City);
            address.City = new City()
            {
                Id = idCity
            };
            return addressService.Insert(address);
        }

        [HttpGet(Name = "GetAllAddress")]
        public List<Address> GetAll()
        {
            return addressService.GetAll();
        }

        [HttpDelete(Name = "DeleteAddress")]
        public bool Delete(int id)
        {
            return addressService.Delete(id);
        }

        [HttpPut(Name = "UpdateAddress")]
        public bool UpDate(Address address)
        {
            return addressService.UpDate(address);
        }
    }
}
    

