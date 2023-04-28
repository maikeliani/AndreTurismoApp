using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Ticket
    {
        public readonly static string INSERT = "insert into Ticket ( SourceAdress, DestinationAdress, IdClient, Dt_Register, Price) " +
            "values (@SourceAdress, @DestinationAdress, @IdClient, @Dt_Register, @Price );  Select cast(scope_identity() as int)";
        public readonly static string GETALL = " select Id, SourceAdress, DestinationAdress, IdClient, Dt_Register, Price from Ticket";
        public readonly static string DELETE = " delete from Ticket where Id = @Id";
        public readonly static string UPDATE = " update  Ticket set SourceAdress = @SourceAdress, DestinationAdress = @DestinationAdress, IdClient = @IdClient, Price = @Price where Id = @Id";


        public int Id { get; set; }

        public Address SourceAddress { get; set; }

        public Address DestinationAddress { get; set; }

        public Client Client { get; set; }

        public DateTime Dt_Register { get; set; }

        public double Price { get; set; }

      
    }
}
