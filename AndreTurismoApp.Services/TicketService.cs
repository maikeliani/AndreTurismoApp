using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories;

namespace AndreTurismoApp.Services
{
    public class TicketService
    {
        private ITicketRepository ticketRepository;

        public TicketService()
        {
            ticketRepository = new TicketRepository();
        }

        public int Insert(Ticket ticket)
        {
            return ticketRepository.Insert(ticket);
        }

        public List<Ticket> GetAll()
        {
            return ticketRepository.GetAll();
        }

        public bool Delete(int id)
        {
            return ticketRepository.Delete(id);
        }

        public bool UpDate(Ticket ticket)
        {
            return ticketRepository.Update(ticket);
        }

    }
}
