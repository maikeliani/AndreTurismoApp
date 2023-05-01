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
        private HotelService _hotelService;
        public HotelController()
        {
            _hotelService = new HotelService();
        }

        [HttpPost(Name = "PostHotel")]
        public async Task<Hotel>PostHotel(Hotel hotel)
        {
            return await _hotelService.PostHotel(hotel);
        }


        [HttpGet]
        public   ActionResult <List<Hotel>> GetHotels()
        {
            return   _hotelService.GetHotels().Result;
        }

        [HttpGet("{id}", Name = "BuscarHotelPorId")]
        public async Task<Hotel> GetHotel(int id)
        {
            return await _hotelService.GetHotel(id);
        }

        [HttpDelete("{id}")]
        public async Task<Hotel> Delete(int id)
        {
            return await _hotelService.Delete(id);
        }
    }
}
