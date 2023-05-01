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
    }
}
