using System.Net;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
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
                

                else
                    return null;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        //public async Task<ActionResult> PutAddresses(int id, Address address)
        //{
        //    try
        //    {
        //        if (id != address.Id)
        //        {
        //            throw new HttpResponseException(HttpStatusCode.BadRequest);

        //        }
        //        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/JSON");

        //        HttpResponseMessage resposta = await _httpClient.PutAsync("https://localhost:7194/api/Addresses", httpContent);
        //        resposta.EnsureSuccessStatusCode();
        //        return null;   //ver retornooo
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        throw;
        //    }
        //}


        public async Task<Address> PutAddress(Address c)
        {
            try
            {
                HttpResponseMessage response = await AddressService._httpClient.PutAsJsonAsync("https://localhost:7194/api/Addresses" + $"/{c.Id}", c);
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<Address> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await AddressService._httpClient.DeleteAsync("https://localhost:7194/api/Addresses" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address); //deleta mas da erro no retorno pois o objeto ja foi deletado
                
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }



    }
}
