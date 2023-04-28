using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories;

namespace AndreTurismoApp.Services
{
    public class ClientService
    {
        private IClientRepository clientRepository;

        public ClientService()
        {
            clientRepository = new ClientRepository();
        }

        public int Insert(Client client)
        {
            return clientRepository.Insert(client);
        }

        public List<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        public bool Delete(int id)
        {
            return clientRepository.Delete(id);
        }

        public bool Update(Client client)
        {
            return clientRepository.Update(client);
        }
    }
}
