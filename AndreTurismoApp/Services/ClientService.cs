using System.Net;
using System.Text;
using AndreTurismoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class ClientService
    {
        static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Client>> GetClients()
        {
            try
            {

                HttpResponseMessage response = await ClientService._httpClient.GetAsync("https://localhost:7021/api/Clients");
                response.EnsureSuccessStatusCode();
                string client = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Client>>(client);
            }
            catch (HttpRequestException e)
            {
                throw;
            }

        }

        public async Task<Client> PostClient(Client client)
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/JSON");

                HttpResponseMessage resposta = await _httpClient.PostAsync("https://localhost:7021/api/Clients", httpContent);
                resposta.EnsureSuccessStatusCode();
                return client;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Client> GetClient(int id)
        {
            try
            {
                List<Client> list = new List<Client>();
                HttpResponseMessage response = await ClientService._httpClient.GetAsync("https://localhost:7021/api/Clients");
                response.EnsureSuccessStatusCode();
                string clients = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<Client>>(clients).ToList();
                if (list != null)
                    return list.Where(a => a.Id == id).First();


                else
                    return null;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Client> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await ClientService._httpClient.DeleteAsync("https://localhost:7021/api/Clients" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string clients = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Client>(clients); 

            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
