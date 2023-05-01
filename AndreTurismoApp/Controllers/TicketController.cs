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

        [HttpGet("{id}", Name = "BuscaTicketPorId")]
        public async Task<Ticket> GetTicket(int id)
        {
            return await _ticketService.GetTicket(id);
        }



        [HttpDelete("{id}")]
        public async Task<Ticket> Delete(int id)
        {
            return await _ticketService.Delete(id);
        }
    }
}
