using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.Repositories
{
    public interface ITicketRepository
    {
        int Insert(Ticket ticket);

        List<Ticket> GetAll();
        bool Delete(int id);
        bool Update(Ticket ticket);
    }
}
