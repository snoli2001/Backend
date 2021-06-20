using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.NotificationDogWalker;

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
        public async Task<IEnumerable<NotificationDogWalkerModel>> GetNotificationDogWalkers()
        {
            var notificationDogWalkerList = await _context.NotificationDogWalkers.ToListAsync();

            return notificationDogWalkerList.Select(d => new NotificationDogWalkerModel
            {
                NotificationDogWalkerId = d.NotificationDogWalkerId,
                DogWalkerId = d.DogWalkerId,
                ShippingDate = d.ShippingDate,
                Description = d.Description,
                AcceptDeny = d.AcceptDeny
            });
        }

        // GET: api/NotificationDogWalkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDogWalker>> GetNotificationDogWalker(int id)
        {
            var notificationDogWalker = await _context.NotificationDogWalkers.FindAsync(id);

            if (notificationDogWalker == null)
                return NotFound();

            return Ok(new NotificationDogWalker
            {
                NotificationDogWalkerId = notificationDogWalker.NotificationDogWalkerId,
                DogWalkerId = notificationDogWalker.DogWalkerId,
                ShippingDate = notificationDogWalker.ShippingDate,
                Description = notificationDogWalker.Description,
                AcceptDeny = notificationDogWalker.AcceptDeny
            });
        }

        // PUT: api/NotificationDogWalkers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationDogWalker(int id, [FromBody] UpdateNotificationDogWalker model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var notificationDogWalker = await _context.NotificationDogWalkers.FirstOrDefaultAsync(d => d.NotificationDogWalkerId == id);

            if (notificationDogWalker == null)
                return NotFound();

            notificationDogWalker.AcceptDeny = model.AcceptDeny;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(model);
        }

        // POST: api/NotificationDogWalkers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostNotificationDogWalker([FromBody] CreateNotificationDogWalkerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            NotificationDogWalker notificationDogWalker = new NotificationDogWalker
            {
                DogWalkerId=model.DogWalkerId,
                ShippingDate = DateTime.Now,
                Description = model.Description,
                //AcceptDeny=model.AcceptDeny
                
            };
            _context.NotificationDogWalkers.Add(notificationDogWalker);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(model);
        }

        // DELETE: api/NotificationDogWalkers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationDogWalker(int id)
        {
            var existingNotificationDogWalker = await _context.NotificationDogWalkers.FindAsync(id);
            if (existingNotificationDogWalker == null)
                return NotFound();

            try
            {
                _context.Remove(existingNotificationDogWalker);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingNotificationDogWalker);
        }

        private bool NotificationDogWalkerExists(int id)
        {
            return _context.NotificationDogWalkers.Any(e => e.NotificationDogWalkerId == id);
        }
    }
}
