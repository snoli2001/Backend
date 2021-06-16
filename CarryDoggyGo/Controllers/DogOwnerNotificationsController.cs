using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.DogOwnerNotification;

namespace CarryDoggyGo.Controllers
{
    [Route("api/DogOwners/")]
    [ApiController]
    public class DogOwnerNotificationsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogOwnerNotificationsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        //// GET: api/DogOwnerNotifications
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DogOwnerNotification>>> GetDogOwnerNotifications()
        //{
        //    return await _context.DogOwnerNotifications.ToListAsync();
        //}

        // GET: api/DogOwnerNotifications/5
        [HttpGet("{dogOwnerId}/DogOwnerNotifications")]
        public async Task<ActionResult<DogOwnerNotification>> GetDogOwnerNotification(int dogOwnerId)
        {
            IEnumerable<DogOwnerNotification> dogList = await _context.DogOwnerNotifications.ToListAsync();

            var dogOwnerNotificationListByDogOwnerId = dogList.ToList().Where(d => d.DogOwnerId == dogOwnerId);

            if (dogOwnerNotificationListByDogOwnerId.Count() > 0)
            {
                return Ok(dogOwnerNotificationListByDogOwnerId.Select(d => new DogOwnerNotificationModel
                {
                    DogOwnerNotificationId = d.DogOwnerNotificationId,
                    Description = d.Description,
                    CreatedAt = d.CreatedAt,
                    DogOwnerId = d.DogOwnerId,
                }));
            }
            else
            {
                return Ok("No hay notificacion(es) para el dueño del perro.");
            }
        }

        //// PUT: api/DogOwnerNotifications/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDogOwnerNotification(int id, DogOwnerNotification dogOwnerNotification)
        //{
        //    if (id != dogOwnerNotification.DogOwnerNotificationId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dogOwnerNotification).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DogOwnerNotificationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/DogOwnerNotifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{dogOwnerId}/DogOwnerNotifications")]
        public async Task<ActionResult<DogOwnerNotification>> PostDogOwnerNotification(int dogOwnerId, [FromBody] CreateDogOwnerNotificationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogOwner dogOwner = await _context.DogOwners.FindAsync(dogOwnerId);

            if (dogOwner == null)
                return NotFound();

            DogOwnerNotification dogOwnerNotification = new DogOwnerNotification
            {
                Description = model.Description,
                CreatedAt = DateTime.Now,
                DogOwnerId = dogOwnerId
            };
            _context.DogOwnerNotifications.Add(dogOwnerNotification);
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

        //// DELETE: api/DogOwnerNotifications/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDogOwnerNotification(int id)
        //{
        //    var dogOwnerNotification = await _context.DogOwnerNotifications.FindAsync(id);
        //    if (dogOwnerNotification == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DogOwnerNotifications.Remove(dogOwnerNotification);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DogOwnerNotificationExists(int id)
        //{
        //    return _context.DogOwnerNotifications.Any(e => e.DogOwnerNotificationId == id);
        //}
    }
}
