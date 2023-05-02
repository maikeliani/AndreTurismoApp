using System.Text;
using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class PackageService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Package>>GetPackages()
        {
            try
            {
                HttpResponseMessage response = await PackageService._httpClient.GetAsync("https://localhost:7234/api/Packages");
                response.EnsureSuccessStatusCode();
                string packages = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Package>>(packages);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }



        public async Task<Package> PostPackage(Package package)
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(package), Encoding.UTF8, "application/JSON");

                HttpResponseMessage resposta = await _httpClient.PostAsync("https://localhost:7234/api/Packages", httpContent);
                resposta.EnsureSuccessStatusCode();
                return package;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Package> GetPackage(int id)
        {
            try
            {
                List<Package> list = new List<Package>();
                HttpResponseMessage response = await PackageService._httpClient.GetAsync("https://localhost:7234/api/Packages");
                response.EnsureSuccessStatusCode();
                string packages = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<Package>>(packages).ToList();
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

        public async Task<Package> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await PackageService._httpClient.DeleteAsync("https://localhost:7234/api/Packages" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string packages = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Package>(packages); 

            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
