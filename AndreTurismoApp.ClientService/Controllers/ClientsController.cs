﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.ClientService.Data;
using AndreTurismoApp.Models.DTO;
using AndreTurismoApp.Models;
using System.Net;
using AndreTurismoApp.Services;

namespace AndreTurismoApp.ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AndreTurismoAppClientServiceContext _context;

        public ClientsController(AndreTurismoAppClientServiceContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
          if (_context.Client == null)
          {
              return NotFound();
          }
            return await _context.Client.Include(a => a.Address.City).ToListAsync(); //exibe o endereço completo dos clientes
            

           
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
          if (_context.Client == null)
          {
              return NotFound();
          }
            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
          if (_context.Client == null)
          {
              return Problem("Entity set 'AndreTurismoAppClientServiceContext.Client'  is null.");
          }            

                                                                                   
            var data = PostOfficesService.GetAddress(client.Address.ZipCode).Result; 
            Address ad = new Address();
            City city = new();

            ad.Street = data.Logradouro;
            city.Description = data.City;
            city.Dt_Register = DateTime.Now;
            ad.City = city;
            ad.Number = client.Address.Number;
            ad.NeighborHood = data.Bairro;
            ad.Complement = data.Complemento;
            ad.ZipCode = data.CEP;
            client.Address = ad;

            _context.Client.Include(a => a.Address); 

            
            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (_context.Client == null)
            {
                return NotFound();
            }
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
