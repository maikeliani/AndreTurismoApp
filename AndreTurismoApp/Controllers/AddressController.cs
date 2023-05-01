
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

        [HttpGet(Name = "GetAddress")]
        public async Task<List<Address>> GetAddresses()
        {
            return await addressService.GetAddress();
        }

        [HttpPost(Name = "PostAddresses")]
        public async Task<Address> PostAddress(Address address)
        {
            return await addressService.PostAddresses(address);
        }

        [HttpGet("{id}", Name = "BuscarEndPorId")]
        public async Task<Address> GetAddress(int id)
        {
            return await addressService.GetAddress(id);
        }

        [HttpPut("{id}")]
        public async Task<Address> PutAddress(Address c)
        {
            return await  addressService.PutAddress(c);
        }

        [HttpDelete("{id}")]
        public async Task<Address> Delete(int id)
        {
            return await addressService.Delete(id);
        }
        /*
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
                }*/
    }
}
    

