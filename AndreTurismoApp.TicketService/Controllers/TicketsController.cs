using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;
using AndreTurismoApp.TicketService.Data;
using System.Net;
using AndreTurismoApp.Services;

namespace AndreTurismoApp.TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AndreTurismoAppTicketServiceContext _context;

        public TicketsController(AndreTurismoAppTicketServiceContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
          if (_context.Ticket == null)
          {
              return NotFound();
          }                                             //testeeeeeeeeee
             return await   _context.Ticket.Include(t => t.DestinationAddress.City).Include(t => t.SourceAddress.City).Include(t => t.Client).Include(t => t.Client.Address.City).ToListAsync();
           // return await _context.Ticket
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
          if (_context.Ticket == null)
          {
              return NotFound();
          }
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
          if (_context.Ticket == null)
          {
              return Problem("Entity set 'AndreTurismoAppTicketServiceContext.Ticket'  is null.");
          }//-------------------------teste--------------------------------


                        //montando SourceAddress
            var data = PostOfficesService.GetAddress(ticket.SourceAddress.ZipCode).Result; // comando Result devolve um retorno do mesmo tipo do parametro Task, no caso AddresDTO
            Address adSource = new Address();
            City city = new();

            adSource.Street = data.Logradouro;
            city.Description = data.City;
            city.Dt_Register = DateTime.Now;
            adSource.City = city;
            adSource.Number = ticket.SourceAddress.Number;
            adSource.NeighborHood = data.Bairro;
            adSource.Complement = data.Complemento;
            adSource.ZipCode = data.CEP;
            ticket.SourceAddress = adSource; //add endereço origem no ticket



            //montando DestinationAddress
            var data2 = PostOfficesService.GetAddress(ticket.DestinationAddress.ZipCode).Result; // comando Result devolve um retorno do mesmo tipo do parametro Task, no caso AddresDTO
            Address adDestination = new Address();
            City city2 = new();

            adDestination.Street = data2.Logradouro;
            city2.Description = data2.City;
            city2.Dt_Register = DateTime.Now;
            adDestination.City = city2;
            adDestination.Number = ticket.DestinationAddress.Number;
            adDestination.NeighborHood = data2.Bairro;
            adDestination.Complement = data2.Complemento;
            adDestination.ZipCode = data2.CEP;
            ticket.DestinationAddress = adDestination; //add destination no ticket


            //-------------------------------MONTANDO ENDEREÇO DO CLIENT-------------------


            var data3 = PostOfficesService.GetAddress(ticket.Client.Address.ZipCode).Result; 
            Address addressClient = new Address();
            City city3 = new();

            addressClient.Street = data3.Logradouro;
            city3.Description = data3.City;
            city3.Dt_Register = DateTime.Now;
            addressClient.City = city3;
            addressClient.Number = ticket.DestinationAddress.Number;
            addressClient.NeighborHood = data3.Bairro;
            addressClient.Complement = data3.Complemento;
            addressClient.ZipCode = data3.CEP;
            ticket.Client.Address = addressClient; //add endereco do cliente no ticket





            //----------------------------------------fim teste-----------------------------

            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            if (_context.Ticket == null)
            {
                return NotFound();
            }
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return (_context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
