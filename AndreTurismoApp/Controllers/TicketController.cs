using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private TicketService ticketService;
        public TicketController()
        {
            ticketService = new TicketService();
        }

        [HttpPost(Name = "InsertTicket")]
        public int Insert(Ticket ticket)
        {
            return ticketService.Insert(ticket);
        }

        [HttpGet(Name = "GetAllTickets")]
        public List<Ticket> GetAll()
        {
            return ticketService.GetAll();
        }


        [HttpDelete(Name = "DeleteTicket")]
        public bool Delete(int id)
        {
            return ticketService.Delete(id);
        }

        [HttpPut(Name = "UpdateTicket")]
        public bool UpDate(Ticket ticket)
        {
            return ticketService.UpDate(ticket);
        }
    }
}
