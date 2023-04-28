using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using Dapper;

namespace AndreTurismoApp.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\bancoDapper\bancoDapper.mdf";

        public int Insert(Hotel hotel)
        {
            var id = 0;
            using (var db = new SqlConnection(StrConn))
            {
                id = db.ExecuteScalar<int>(Hotel.INSERT, new { @Name = hotel.Name, @IdAdress = hotel.Address.Id, @Dt_Register = hotel.Dt_Register, @Price = hotel.Price });
            }
            return id;
        }


        public bool Delete(int id)
        {
            var status = false;

            using (var db = new SqlConnection(StrConn))
            {
                db.Execute(Hotel.DELETE, new { @Id = id });
                status = true;
            }
            return status;
        }

        public List<Hotel> GetAll()
        {
            List<Hotel> list = new List<Hotel>();
            using (var db = new SqlConnection(StrConn))
            {
                var hotels = db.Query<Hotel>(Hotel.GETALL);
                list = (List<Hotel>)hotels;
            }
            return list;
        }

        public bool Update(Hotel hotel)
        {
            var status = false;
            using (var db = new SqlConnection(StrConn))
            {
                db.Execute(Hotel.UPDATE, new { @Id = hotel.Id, @Name = hotel.Name, @IdAdress = hotel.Address.Id, @Dt_Register = hotel.Dt_Register, @Price = hotel.Price });

                status = true;
            }
            return status;
        }


    }
}
