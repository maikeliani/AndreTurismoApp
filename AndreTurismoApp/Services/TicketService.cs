using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class TicketService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Ticket>> GetTickets()
        {
            HttpResponseMessage response = await  _httpClient.GetAsync("https://localhost:7118/api/Tickets");
            response.EnsureSuccessStatusCode();
            string tickets =  await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Ticket>>(tickets);
        }
    }
}
