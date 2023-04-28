using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.Repositories
{
    public  interface ICityRepository
    {
        int Insert(City city);

        List<City> GetAll();
        bool Delete(int id);
        bool Update(City city);
    }
}
