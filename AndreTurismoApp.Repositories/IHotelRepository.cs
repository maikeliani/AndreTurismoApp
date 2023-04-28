using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.Repositories
{
    public  interface IHotelRepository
    {
        int Insert(Hotel hotel);

        List<Hotel> GetAll();
        bool Delete(int id);
        bool Update(Hotel hotel);
    }
}
