using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Package
    {
        public readonly static string INSERT = " insert into Package (IdHotel, IdTicket, Dt_Register, Price, IdClient) values ( @IdHotel, @IdTicket, @Dt_Register, @Price, @IdClient);  Select cast(scope_identity() as int)";
        public readonly static string GETALL = " select p.Id , h.Name , a.Street ,a.Number , t.Id ,t.Price  , c.Name , c.Telephone , p.Price  from Package p join Hotel h on p.IdHotel = h.Id join Adress a on a.Id = h.IdAdress join Ticket t on p.IdTicket = t.Id join Client c on c.Id = p.IdClient";
        public readonly static string DELETE = " delete from Package where Id = @Id";
        public readonly static string UPDATE = " update  Package set IdHotel = @IdHotel, IdTicket = @IdTicket, Price = @Price, IdClient = @IdClient where Id = @Id";

        public int Id { get; set; }
        public Hotel Hotel { get; set; }

        public Ticket Ticket { get; set; }

        public DateTime Dt_Register { get; set; }

        public double Price { get; set; }

        public Client Client { get; set; }

        
    }
}
