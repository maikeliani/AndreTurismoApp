using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.CityServices.Data
{
    public class AndreTurismoAppCityServicesContext : DbContext
    {
        public AndreTurismoAppCityServicesContext (DbContextOptions<AndreTurismoAppCityServicesContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.City> City { get; set; } = default!;
    }
}
