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
        private PackageService packageService;
        public PackageController()
        {
            packageService = new PackageService();
        }
        [HttpPost(Name = "InsertPackage")]
        public int Insert(Package package)
        {
            return packageService.Insert(package);
        }
        [HttpGet(Name ="GellAllPackages")]
        public List<Package> GetAll()
        {
            return packageService.GetAll();
        }


        [HttpDelete(Name = "DeletePackage")]
        public bool Delete(int id)
        {
            return packageService.Delete(id);
        }
        [HttpPut(Name = "UpdatePackage")]
        public bool Update(Package package)
        {
            return packageService.Update(package);
        }

    }
}
