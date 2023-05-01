using System.Text;
using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class AddressService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Address>> GetAddresses()
        {
            try
            {
                HttpResponseMessage response = await AddressService._httpClient.GetAsync("https://localhost:7194/api/Addresses");
                response.EnsureSuccessStatusCode();
                string addresses = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<List<Address>>(addresses);
            }
            catch (Exception )
            {
                return null;
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
    }
}
