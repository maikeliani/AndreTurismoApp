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
    public class ClientRepository : IClientRepository
    {
        readonly string StrConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security = true;AttachDbFileName = C:\bancoDapper\bancoDapper.mdf";

        public List<Client> GetAll()
        {
            List<Client> list = new List<Client>();
            using (var db = new SqlConnection(StrConn))
            {
                var clients = db.Query<Client>(Client.GETALL);
                list = (List<Client>)clients;
            }
            return list;
        }

        public int Insert(Client client)
        {
            var id = 0;
            using (var db = new SqlConnection(StrConn))
            {
                id = db.ExecuteScalar<int>(Client.INSERT, new { @Name = client.Name, @Telephone = client.Telephone, @IdAdress = client.Address.Id, @Dt_Register = client.Dt_Register });
            }
            return id;
        }

        public bool Delete(int id)
        {
            var status = false;

            using (var db = new SqlConnection(StrConn))
            {

                db.Execute(Client.DELETE, new { @Id = id });
                status = true;

            }
            return status;
        }

        public bool Update(Client client)
        {
            var status = false;
            using (var db = new SqlConnection(StrConn))
            {
                db.Execute(Client.UPDATE, new { @Id = client.Id, @Name = client.Name, @Telephone = client.Telephone, @IdAdress = client.Address.Id, @Dt_Register = client.Dt_Register });

                status = true;
            }
            return status;
        }

    }
}
