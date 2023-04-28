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
    public class CityRepository : ICityRepository
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\bancoDapper\bancoDapper.mdf";


        public int Insert(City city)
        {
            var id = 0;
            using (var db = new SqlConnection(StrConn))
            {

                id = db.ExecuteScalar<int>(City.INSERT, new { @Description = city.Description, @Dt_Register = city.Dt_Register });
            }
            return id;
        }


        public List<City> GetAll()
        {
            List<City> list = new List<City>();
            using (var db = new SqlConnection(StrConn))
            {
                var cities = db.Query<City>(City.GETALL);
                list = (List<City>)cities;
            }
            return list;
        }

        public bool Delete(int id)
        {
            var status = false;
            using (var db = new SqlConnection(StrConn))
            {
                db.Execute(City.DELETE, new { @Id = id });
                status = true;
            }
            return status;
        }

        public bool Update(City city)
        {
            var status = false;
            using (var db = new SqlConnection(StrConn))
            {

                db.Execute(City.UPDATE, new { @Id = city.Id, @Description = city.Description, @Dt_Register = city.Dt_Register });

                status = true;
            }
            return status;
        }

    }
}
