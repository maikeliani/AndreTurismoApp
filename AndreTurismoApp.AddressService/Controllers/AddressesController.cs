using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.AddressService.Data;
using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using AndreTurismoApp.Models.DTO;
using Newtonsoft.Json;
using System.Net;

namespace AndreTurismoApp.AddressService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        
        private readonly AndreTurismoAppAddressServiceContext _context;
        

        public AddressesController(AndreTurismoAppAddressServiceContext context)
        {
            _context = context;
        }



        [HttpGet("{cep:length(8)}")]
        public ActionResult<AddressDTO> GetCEP(string cep)
        {
            return PostOfficesService.GetAddress(cep).Result;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
          if (_context.Address == null)
          {
              return NotFound();
          }
            
            //return await _context.Address.ToListAsync(); //testeee
            return await _context.Address.Include(a => a.City).ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}", Name = "BuscarEndPorId")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
          if (_context.Address == null)
          {
              return NotFound();
          }
            
            var address = await _context.Address.Include(a => a.City).Where(a => a.Id == id).FirstOrDefaultAsync(); // inserido
            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
          if (_context.Address == null)
          {
              return Problem("Entity set 'AndreTurismoAppAddressServiceContext.Address'  is null.");
          }


            var data = PostOfficesService.GetAddress(address.ZipCode).Result; // comando Result devolve um retorno do mesmo tipo do parametro Task, no caso AddresDTO
            Address ad = new Address();
            City city = new();

            ad.Street = data.Logradouro;
            city.Description = data.City;
            city.Dt_Register = DateTime.Now;
            ad.City = city;
            ad.Number = address.Number;
            ad.NeighborHood = data.Bairro;
            ad.Complement = data.Complemento;
            ad.ZipCode = data.CEP;         


            _context.Address.Add(ad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, ad); // colocou ad no fim em vez de address
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
