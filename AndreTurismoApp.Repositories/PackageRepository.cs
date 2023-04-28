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
    public class PackageRepository : IPackageRepository
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\bancoDapper\bancoDapper.mdf";

        public List<Package> GetAll()
        {
            List<Package> list = new List<Package>();
            using (var db = new SqlConnection(StrConn))
            {
                var packages = db.Query<Package>(Package.GETALL);
                list = (List<Package>)packages;
            }
            return list;
        }

        public int Insert(Package package)
        {
            var id = 0;
            using (var db = new SqlConnection(StrConn))
            {
                id = db.ExecuteScalar<int>(Package.INSERT, new { @IdHotel = package.Hotel.Id, @IdTicket = package.Ticket.Id, @Dt_Register = package.Dt_Register, @Price = package.Price, @IdClient = package.Client.Id });
            }
            return id;
        }


        public bool Delete(int id)
        {
            var status = false;
            using (var db = new SqlConnection(StrConn))
            {
                db.Execute(Package.DELETE, new { @Id = id });
                status = true;
            }
            return status;
        }



        public bool UpDate(Package package)
        {
            var status = false;
            using (var db = new SqlConnection(StrConn))
            {
                db.Execute(Package.UPDATE, new { @Id = package.Id, @IdHotel = package.Hotel.Id, @IdTicket = package.Ticket.Id, @Dt_Register = package.Dt_Register, @Price = package.Price, @IdClient = package.Client.Id });
                status = true;
            }
            return status;
        }
    }
}
