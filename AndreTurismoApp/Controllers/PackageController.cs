using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private PackageService _packageService;
        public PackageController()
        {
            _packageService = new PackageService();
        }

        [HttpGet]
        public async Task<List<Package>>GetPackages()
        {
            return await _packageService.GetPackages();
        }


        [HttpPost(Name ="PostPackage")]
        public async Task<Package>PostPackage(Package package)
        {
            return await _packageService.PostPackage(package);
        }

        [HttpGet("{id}", Name = "BuscaPackagePorId")]
        public async Task<Package> GetPackage(int id)
        {
            return await _packageService.GetPackage(id);
        }


        [HttpDelete("{id}")]
        public async Task<Package> Delete(int id)
        {
            return await _packageService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<Package> PutHotel(int id, Package package)
        {
            return await _packageService.PutPackage(id, package);
        }

    }
}
