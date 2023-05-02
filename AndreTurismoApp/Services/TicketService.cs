using System.Net.Http;
using System.Text;
using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class TicketService
    {
        private static readonly HttpClient _httpClient = new HttpClient();  //colokei static

        public async Task<List<Ticket>> GetTickets()
        {
            HttpResponseMessage response = await  _httpClient.GetAsync("https://localhost:7118/api/Tickets");
            response.EnsureSuccessStatusCode();
            string tickets =  await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Ticket>>(tickets);
        }

        public async Task<Ticket> PostTicket(Ticket ticket)
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, "application/JSON");

                HttpResponseMessage resposta = await _httpClient.PostAsync("https://localhost:7118/api/Tickets", httpContent);
                resposta.EnsureSuccessStatusCode();
                return ticket;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Ticket> GetTicket(int id)
        {
            try
            {
                List<Ticket> list = new List<Ticket>();
                HttpResponseMessage response = await TicketService._httpClient.GetAsync("https://localhost:7118/api/Tickets");
                response.EnsureSuccessStatusCode();
                string tickets = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<Ticket>>(tickets).ToList();
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


        public async Task<Ticket> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await TicketService._httpClient.DeleteAsync("https://localhost:7118/api/Tickets" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string tickets = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(tickets); 

            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

    }

   
}
