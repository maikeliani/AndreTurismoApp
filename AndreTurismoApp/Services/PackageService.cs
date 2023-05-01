using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class PackageService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Package>>GetPackages()
        {
            HttpResponseMessage response = await  PackageService._httpClient.GetAsync("https://localhost:7234/api/Packages"); 
            response.EnsureSuccessStatusCode();
            string packages = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Package>>(packages);
        }
    }
}
