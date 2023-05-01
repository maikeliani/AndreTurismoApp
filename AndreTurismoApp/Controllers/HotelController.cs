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
/*
        [HttpDelete(Name = "DeleteHotel")]
        public bool Delete(int id)
        {
            return hotelService.Delete(id);
        }

        [HttpPut(Name ="UpdateHotel")]
        public bool Update(Hotel hotel)
        {
            return hotelService.Update(hotel);
        }*/
    }
}
