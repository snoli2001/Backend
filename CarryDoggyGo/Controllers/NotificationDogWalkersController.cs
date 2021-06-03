using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationDogWalkersController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public NotificationDogWalkersController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/NotificationDogWalkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationDogWalker>>> GetNotificationDogWalkers()
        {
            return await _context.NotificationDogWalkers.ToListAsync();
        }

        // GET: api/NotificationDogWalkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDogWalker>> GetNotificationDogWalker(int id)
        {
            var notificationDogWalker = await _context.NotificationDogWalkers.FindAsync(id);

            if (notificationDogWalker == null)
            {
                return NotFound();
            }

            return notificationDogWalker;
        }

        // PUT: api/NotificationDogWalkers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationDogWalker(int id, NotificationDogWalker notificationDogWalker)
        {
            if (id != notificationDogWalker.NotificationDogWalkerId)
            {
                return BadRequest();
            }

            _context.Entry(notificationDogWalker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationDogWalkerExists(id))
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

        // POST: api/NotificationDogWalkers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotificationDogWalker>> PostNotificationDogWalker(NotificationDogWalker notificationDogWalker)
        {
            _context.NotificationDogWalkers.Add(notificationDogWalker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificationDogWalker", new { id = notificationDogWalker.NotificationDogWalkerId }, notificationDogWalker);
        }

        // DELETE: api/NotificationDogWalkers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationDogWalker(int id)
        {
            var notificationDogWalker = await _context.NotificationDogWalkers.FindAsync(id);
            if (notificationDogWalker == null)
            {
                return NotFound();
            }

            _context.NotificationDogWalkers.Remove(notificationDogWalker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificationDogWalkerExists(int id)
        {
            return _context.NotificationDogWalkers.Any(e => e.NotificationDogWalkerId == id);
        }
    }
}
