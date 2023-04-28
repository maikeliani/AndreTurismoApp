using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories;
namespace AndreTurismoApp.Services
{
    public class AddressService
    {
        private IAddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }

        public int Insert(Address address)
        {
            return addressRepository.Insert(address);
        }

        public List<Address> GetAll()
        {
            return addressRepository.GetAll();
        }

        public bool Delete(int id)
        {
            return addressRepository.Delete(id);
        }

        public bool UpDate(Address address)
        {
            return addressRepository.Update(address);
        }


    }
}