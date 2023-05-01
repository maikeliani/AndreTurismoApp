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
        private TicketService _ticketService;
        public TicketController()
        {
            _ticketService = new TicketService();
        }

        [HttpGet]
        public async Task<List<Ticket>> GetTickets()
        {
            return  await _ticketService.GetTickets();
        }

        [HttpPost(Name = "PostTicket")]
        public async Task<Ticket>GetTickets(Ticket ticket)
        {
            return await _ticketService.PostTicket(ticket);
        }
/*
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
        }*/
    }
}
