using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
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

        //perguntar Professor
        //public async Task<HttpStatusCode> PostCity(City city)
        //{
        //    HttpResponseMessage response = await CityService._httpClient.PostAsJsonAsync("https://localhost:8082/api/Cities", city);
        //    return response.StatusCode;
        //}

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
                return JsonConvert.DeserializeObject<City>(cities); 

            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

            //perguntar pq precisa passar o id 2 vezes pra dar updat2
        public async Task<City> PutCity(int id, City c)
        {
            try
            {
                HttpResponseMessage response = await CityService._httpClient.PutAsJsonAsync("https://localhost:7278/api/Cities" + $"/{id}", c);
                response.EnsureSuccessStatusCode();
                string cities = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(cities);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        // exemplo codigo naiara -- so nao usou HttpStatusCode nos GET's
        /* public async Task<HttpStatusCode> PutCity(City city)
         {
             HttpResponseMessage response = await CityService._httpClient.PutAsJsonAsync("https://localhost:7278/api/Cities", city);
             return response.StatusCode;
         }*/
    }
}
