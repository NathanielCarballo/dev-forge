using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarApp.Db;
using CarApp.Models;

namespace CarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceWorkItems : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServiceWorkItems(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceWorkItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceWorkItem>>> GetServiceWorkItems()
        {
          if (_context.ServiceWorkItems == null)
          {
              return NotFound();
          }
            return await _context.ServiceWorkItems.ToListAsync();
        }

        // GET: api/ServiceWorkItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceWorkItem>> GetServiceWorkItem(int id)
        {
          if (_context.ServiceWorkItems == null)
          {
              return NotFound();
          }
            var serviceWorkItem = await _context.ServiceWorkItems.FindAsync(id);

            if (serviceWorkItem == null)
            {
                return NotFound();
            }

            return serviceWorkItem;
        }

        // PUT: api/ServiceWorkItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceWorkItem(int id, ServiceWorkItem serviceWorkItem)
        {
            if (id != serviceWorkItem.ServiceId)
            {
                return BadRequest();
            }

            _context.Entry(serviceWorkItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceWorkItemExists(id))
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

        // POST: api/ServiceWorkItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceWorkItem>> PostServiceWorkItem(ServiceWorkItem serviceWorkItem)
        {
          if (_context.ServiceWorkItems == null)
          {
              return Problem("Entity set 'AppDbContext.ServiceWorkItems'  is null.");
          }
            _context.ServiceWorkItems.Add(serviceWorkItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceWorkItemExists(serviceWorkItem.ServiceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServiceWorkItem", new { id = serviceWorkItem.ServiceId }, serviceWorkItem);
        }

        // DELETE: api/ServiceWorkItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceWorkItem(int id)
        {
            if (_context.ServiceWorkItems == null)
            {
                return NotFound();
            }
            var serviceWorkItem = await _context.ServiceWorkItems.FindAsync(id);
            if (serviceWorkItem == null)
            {
                return NotFound();
            }

            _context.ServiceWorkItems.Remove(serviceWorkItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceWorkItemExists(int id)
        {
            return (_context.ServiceWorkItems?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
