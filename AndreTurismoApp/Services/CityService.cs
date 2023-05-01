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
            catch(Exception) 
            {
                return null;
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
    }
}
