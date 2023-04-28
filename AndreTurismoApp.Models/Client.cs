using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Client
    {
        public readonly static string INSERT = " insert into Client (Name, Telephone, IdAdress, Dt_Register) values ( @Name, @Telephone, @IdAdress, @Dt_Register ); Select cast(scope_identity() as int)";
        public readonly static string GETALL = " select Id, Name, Telephone, IdAdress, Dt_Register from Client";
        public readonly static string DELETE = " delete from Client where Id = @Id";
        public readonly static string UPDATE = " update Client set Name = @Name, Telephone = @Telephone, IdAdress = @IdAdress, Dt_Register = @Dt_Register where Id = @Id";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        public Address Address { get; set; }

        public DateTime Dt_Register { get; set; }


    }
}