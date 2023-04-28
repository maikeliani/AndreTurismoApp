using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.Repositories
{
    public  interface IClientRepository
    {
        int Insert(Client client);

        List<Client> GetAll();
        bool Delete(int id);
        bool Update(Client client);
    }
}
