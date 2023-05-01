using System.Text;
using AndreTurismoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class AddressService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Address>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await AddressService._httpClient.GetAsync("https://localhost:7194/api/Addresses");
                response.EnsureSuccessStatusCode();
                string addresses = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<List<Address>>(addresses);
            }
            catch (HttpRequestException e)
            {
                throw;
            }



        }

        public async Task<Address> PostAddresses(Address address)
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/JSON");

                HttpResponseMessage resposta = await _httpClient.PostAsync("https://localhost:7194/api/Addresses", httpContent);
                resposta.EnsureSuccessStatusCode();
                return address;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Address> GetAddress(int id)
        {
             try
            {
                List<Address> list = new List<Address>();
                HttpResponseMessage response = await AddressService._httpClient.GetAsync("https://localhost:7194/api/Addresses");
                response.EnsureSuccessStatusCode();                
                string addresses = await response.Content.ReadAsStringAsync();                
                list = JsonConvert.DeserializeObject<List<Address>>(addresses).ToList(); // colokei tolist n ofinal pra teste
                if (list != null)
                    return (Address)list.Where(a => a.Id == id).First();
                // var address = await _context.Address.Include(a => a.City).Where(a => a.Id == id).FirstOrDefaultAsync(); // inserido

                else
                    return null;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
