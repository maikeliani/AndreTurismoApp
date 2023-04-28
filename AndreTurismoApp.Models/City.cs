namespace AndreTurismoApp.Models
{
    public class City
    {
        public readonly static string INSERT = " insert into City (Description, Dt_Register) values ( @Description, @Dt_Register); Select cast(scope_identity() as int)";
        public readonly static string GETALL = " select Id, Description, Dt_Register from City";
        public readonly static string DELETE = " delete from City where Id = @Id";
        public readonly static string UPDATE = " update  City set Description = @Description where Id = @Id";


        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Dt_Register { get; set; }


        
    }
}