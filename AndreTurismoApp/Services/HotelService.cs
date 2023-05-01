using System.Text;
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


        public async Task<Hotel> PostHotel(Hotel hotel)
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(hotel), Encoding.UTF8, "application/JSON");

                HttpResponseMessage resposta = await _httpClient.PostAsync("https://localhost:7261/api/Hotels", httpContent);
                resposta.EnsureSuccessStatusCode();
                return hotel;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
