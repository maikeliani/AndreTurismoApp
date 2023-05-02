using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;
using AndreTurismoApp.PackageService.Data;
using System.Net.Sockets;
using AndreTurismoApp.Services;

namespace AndreTurismoApp.PackageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly AndreTurismoAppPackageServiceContext _context;

        public PackagesController(AndreTurismoAppPackageServiceContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackage()
        {
          if (_context.Package == null)
          {
              return NotFound();
          }                                         //teste retorno completo
            return await _context.Package.Include(p => p.Client).Include(p => p.Client.Address.City).Include(p => p.Hotel.Address.City).Include(p => p.Ticket.SourceAddress.City).Include(p=> p.Ticket.Client.Address.City).Include(p => p.Ticket.DestinationAddress.City).ToListAsync();
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
          if (_context.Package == null)
          {
              return NotFound();
          }
            var package = await _context.Package.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, Package package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
          if (_context.Package == null)
          {
              return Problem("Entity set 'AndreTurismoAppPackageServiceContext.Package'  is null.");
          }
            //--------------------------------testeeee-------------------------------------

                                                            //criando ticket!!

            //montando SourceAddress
            var data = PostOfficesService.GetAddress(package.Ticket.SourceAddress.ZipCode).Result; // comando Result devolve um retorno do mesmo tipo do parametro Task, no caso AddresDTO
            Address adSource = new Address();
            City city = new();

            adSource.Street = data.Logradouro;
            city.Description = data.City;
            city.Dt_Register = DateTime.Now;
            adSource.City = city;
            adSource.Number = package.Ticket.SourceAddress.Number;
            adSource.NeighborHood = data.Bairro;
            adSource.Complement = data.Complemento;
            adSource.ZipCode = data.CEP;
            package.Ticket.SourceAddress = adSource; //add endereço origem no ticket



            //montando DestinationAddress
            var data2 = PostOfficesService.GetAddress(package.Ticket.DestinationAddress.ZipCode).Result; // comando Result devolve um retorno do mesmo tipo do parametro Task, no caso AddresDTO
            Address adDestination = new Address();
            City city2 = new();

            adDestination.Street = data2.Logradouro;
            city2.Description = data2.City;
            city2.Dt_Register = DateTime.Now;
            adDestination.City = city2;
            adDestination.Number = package.Ticket.DestinationAddress.Number;
            adDestination.NeighborHood = data2.Bairro;
            adDestination.Complement = data2.Complemento;
            adDestination.ZipCode = data2.CEP;
            package.Ticket.DestinationAddress = adDestination; //add destination no ticket


            //-------------------------------MONTANDO ENDEREÇO DO CLIENT-------------------


            var data3 = PostOfficesService.GetAddress(package.Ticket.Client.Address.ZipCode).Result;
            Address addressClient = new Address();
            City city3 = new();

            addressClient.Street = data3.Logradouro;
            city3.Description = data3.City;
            city3.Dt_Register = DateTime.Now;
            addressClient.City = city3;
            addressClient.Number = package.Ticket.DestinationAddress.Number;
            addressClient.NeighborHood = data3.Bairro;
            addressClient.Complement = data3.Complemento;
            addressClient.ZipCode = data3.CEP;
            package.Ticket.Client.Address = addressClient; //add endereco do cliente no ticket do package


            //-------------------------------------- MONTANDO ENDEREÇO HOTEL -----------------


            var data4 = PostOfficesService.GetAddress(package.Ticket.Client.Address.ZipCode).Result;
            Address addressHotel = new Address();
            City city4 = new();

            addressHotel.Street = data4.Logradouro;
            city4.Description = data4.City;
            city4.Dt_Register = DateTime.Now;
            addressHotel.City = city4;
            addressHotel.Number = package.Ticket.DestinationAddress.Number;
            addressHotel.NeighborHood = data4.Bairro;
            addressHotel.Complement = data4.Complemento;
            addressHotel.ZipCode = data4.CEP;
            package.Hotel.Address = addressHotel; //add endereco do hotel no  package


            //----------------------------------fim teste--------------------------------

            _context.Package.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            if (_context.Package == null)
            {
                return NotFound();
            }
            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageExists(int id)
        {
            return (_context.Package?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
