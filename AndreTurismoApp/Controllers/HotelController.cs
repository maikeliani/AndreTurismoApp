using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private HotelService hotelService;
        public HotelController()
        {
            hotelService = new HotelService();
        }

        [HttpPost(Name = "InsertHotel")]
        public int Insert(Hotel hotel)
        {
            return hotelService.Insert(hotel);
        }

        [HttpGet(Name = "GetAllHotels")]
        public List<Hotel> GetAll()
        {
            return hotelService.GetAll();
        }

        [HttpDelete(Name = "DeleteHotel")]
        public bool Delete(int id)
        {
            return hotelService.Delete(id);
        }

        [HttpPut(Name ="UpdateHotel")]
        public bool Update(Hotel hotel)
        {
            return hotelService.Update(hotel);
        }
    }
}
