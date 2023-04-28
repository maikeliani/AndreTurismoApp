using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Hotel
    {
        public readonly static string INSERT = " insert into Hotel (Name, IdAdress, Dt_Register, Price ) " +
            "values ( @Name, @IdAdress, @Dt_Register, @Price);  Select cast(scope_identity() as int)";
        public readonly static string GETALL = " select Id, Name, IdAdress, Dt_Register, Price from Hotel";
        public readonly static string DELETE = " delete from Hotel where Id = @Id";
        public readonly static string UPDATE = " update  Hotel set Name = @Name, IdAdress = @IdAdress, Price = @Price where Id = @Id";


        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public DateTime Dt_Register { get; set; }

        public double Price { get; set; }

        
    }
}
