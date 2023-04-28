using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories;

namespace AndreTurismoApp.Services
{
    public class PackageService
    {
        private IPackageRepository packageRepository;

        public PackageService()
        {
            packageRepository = new PackageRepository();
        }

        public int Insert(Package package)
        {
            return packageRepository.Insert(package);
        }

        public List<Package> GetAll()
        {
            return packageRepository.GetAll();
        }

        public bool Delete(int id)
        {
            return packageRepository.Delete(id);
        }

        public bool Update(Package package)
        {
            return packageRepository.UpDate(package);
        }

    }
}
