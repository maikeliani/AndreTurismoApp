using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Address
    {
        public readonly static string INSERT = " insert into Adress (Street, Number, NeighborHood, ZipCode, " +
            "Complement, IdCity, Dt_Register) values ( @Street, @Number, @NeighborHood, @ZipCode, @Complement, @IdCity, @Dt_Register); Select cast(scope_identity() as int)";
        public readonly static string GETALL = " select Id, Street, Number, NeighborHood, ZipCode, Complement," +
            " IdCity, Dt_Register from Adress";
        public readonly static string DELETE = " delete from Adress where Id =@Id";
        public readonly static string UPDATE = "update Adress set Street =  @Street, Number = @Number, NeighborHood = @NeighborHood, ZipCode = @ZipCode, Complement = @Complement where Id = @Id";

        public int Id { get; set; }
        public string Street { get; set; }

        public int Number { get; set; }

        public string NeighborHood { get; set; }

        public string ZipCode { get; set; }

        public string Complement { get; set; }

        public City City { get; set; }

        public DateTime Dt_Register { get; set; }



    }
}
