using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using AndreTurismoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class CityService
    {
        private static readonly HttpClient _httpClient=new HttpClient();  //colokei static
        
        public async Task<List<City>> GetCities()
        {
            try
            {

                HttpResponseMessage response = await CityService._httpClient.GetAsync("https://localhost:7278/api/Cities");
                response.EnsureSuccessStatusCode();                
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }

        }

        public async Task<City> PostCity(City city)
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/JSON");

                HttpResponseMessage resposta = await _httpClient.PostAsync("https://localhost:7278/api/Cities", httpContent);
                resposta.EnsureSuccessStatusCode();
                return city;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<City> GetCity(int id)
        {
            try
            {
                List<City> list = new List<City>();
                HttpResponseMessage response = await CityService._httpClient.GetAsync("https://localhost:7278/api/Cities");
                response.EnsureSuccessStatusCode();
                string cities = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<City>>(cities).ToList();
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

        public async Task<City> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await CityService._httpClient.DeleteAsync("https://localhost:7278/api/Cities" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string cities = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(cities); //deleta mas da erro no retorno pois o objeto ja foi deletado

            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
