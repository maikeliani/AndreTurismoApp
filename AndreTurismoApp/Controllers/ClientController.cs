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


        [HttpGet("{id}", Name = "BuscarClientPorId")]
        public async Task<Client> GetClient(int id)
        {
            return await _clientService.GetClient( id);
        }


        [HttpDelete("{id}")]
        public async Task<Client> Delete(int id)
        {
            return await _clientService.Delete(id);
        }
       
    }
}
