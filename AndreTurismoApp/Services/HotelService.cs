using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class HotelService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<List<Hotel>> GetHotels()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7261/api/Hotels");
                response.EnsureSuccessStatusCode();
                string hotels = await response.Content.ReadAsStringAsync();
                 var resultado = JsonConvert.DeserializeObject<List<Hotel>>(hotels);
                return resultado;

            }
            catch(Exception )
            {
                return null;
            }
        }
    }
}
