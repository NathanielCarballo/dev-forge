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
    public class WorkOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkOrder>>> GetWorkOrders()
        {
          if (_context.WorkOrders == null)
          {
              return NotFound();
          }
            return await _context.WorkOrders.ToListAsync();
        }

        // GET: api/WorkOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkOrder>> GetWorkOrder(int id)
        {
          if (_context.WorkOrders == null)
          {
              return NotFound();
          }
            var workOrder = await _context.WorkOrders.FindAsync(id);

            if (workOrder == null)
            {
                return NotFound();
            }

            return workOrder;
        }

        // PUT: api/WorkOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkOrder(int id, WorkOrder workOrder)
        {
            if (id != workOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(workOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkOrderExists(id))
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

        // POST: api/WorkOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkOrder>> PostWorkOrder(WorkOrder workOrder)
        {
            
          if (_context.WorkOrders == null)
          {
              return Problem("Entity set 'AppDbContext.WorkOrders'  is null.");
          }
            workOrder.ModifiedDt = DateTime.Now;
            _context.WorkOrders.Add(workOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkOrder", new { id = workOrder.Id }, workOrder);
        }

        // DELETE: api/WorkOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOrder(int id)
        {
            if (_context.WorkOrders == null)
            {
                return NotFound();
            }
            var workOrder = await _context.WorkOrders.FindAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            _context.WorkOrders.Remove(workOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkOrderExists(int id)
        {
            return (_context.WorkOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
