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
            catch (HttpRequestException e)
            {
                throw;
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

        public async Task<Hotel> GetHotel(int id)
        {
            try
            {
                List<Hotel> list = new List<Hotel>();
                HttpResponseMessage response = await HotelService._httpClient.GetAsync("https://localhost:7261/api/Hotels");
                response.EnsureSuccessStatusCode();
                string hotels = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<Hotel>>(hotels).ToList();
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

        public async Task<Hotel> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await HotelService._httpClient.DeleteAsync("https://localhost:7261/api/Hotels" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string hotels = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotels); //deleta mas da erro no retorno pois o objeto ja foi deletado

            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

    }
}
