using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories;

namespace AndreTurismoApp.Services
{
    public class HotelService
    {
        private IHotelRepository hotelRepository;

        public HotelService()
        {
            hotelRepository = new HotelRepository();
        }

        public int Insert(Hotel hotel)
        {
            return hotelRepository.Insert(hotel);
        }

        public List<Hotel> GetAll()
        {
            return hotelRepository.GetAll();
        }

        public bool Delete(int id)
        {
            return hotelRepository.Delete(id);
        }

        public bool Update(Hotel hotel)
        {
            return hotelRepository.Update(hotel);
        }


    }
}
