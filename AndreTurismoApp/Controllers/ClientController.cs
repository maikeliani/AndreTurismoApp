using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ClientService _clientService;
        public ClientController()
        {
            _clientService = new ClientService();
        }

        [HttpGet(Name = "GetAllClients")]
        public async Task<List<Client>> GetAll()
        {
            return await _clientService.GetClients();
        }

        [HttpPost(Name ="PostClient")]
        public async Task<Client>PostClient(Client client)
        {
            return await _clientService.PostClient( client);

        }
/*
        [HttpPost(Name = "InsertClient")]
        public int Insert(Client client)
        {
            return clientService.Insert(client);
        }
        [HttpGet(Name = "GetAllClients")]
        public List<Client> GetAll()
        {
            return clientService.GetAll();
        }

        [HttpDelete(Name = "DeleteClient")]
        public bool Delete(int id)
        {
            return clientService.Delete(id);
        }
        [HttpPut(Name = "UpdateClient")]
        public bool Update(Client client)
        {
            return clientService.Update(client);
        }*/
    }
}
