using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Message;

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogWalkMessagesController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogWalkMessagesController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        //// GET: api/DogWalkMessages
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DogWalkMessage>>> GetDogWalkMessages()
        //{
        //    return await _context.DogWalkMessages.ToListAsync();
        //}

        // GET: api/DogWalkMessages/5
        [HttpGet("{dogWalkId}/Messages")]
        public async Task<ActionResult<Message>> GetDogWalkMessage(int dogWalkId)
        {
            IEnumerable<Message> dogList = await _context.Messages.ToListAsync();

            var dogWalkMessageListByDogWalkId = dogList.ToList().Where(d => d.DogWalkId == dogWalkId);

            if (dogWalkMessageListByDogWalkId.Count() > 0)
            {
                return Ok(dogWalkMessageListByDogWalkId.Select(d => new MessageModel
                {
                    MessageId = d.MessageId,
                    Text = d.Text,
                    IsImportant = d.IsImportant,
                    CreatedAt = d.CreatedAt,
                    DogWalkId = d.DogWalkId,
                }));
            }
            else
            {
                return Ok("No hay messagee(s) para el dueño del perro.");
            }
        }

        //// PUT: api/DogWalkMessages/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDogWalkMessage(int id, DogWalkMessage dogWalkMessage)
        //{
        //    if (id != dogWalkMessage.DogWalkMessageId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dogWalkMessage).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DogWalkMessageExists(id))
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

        // POST: api/DogWalkMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{dogWalkId}/Messages")]
        public async Task<ActionResult<Message>> PostDogWalkMessage(int dogWalkId, [FromBody] CreateMessageModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogWalk dogWalk = await _context.DogWalks.FindAsync(dogWalkId);

            if (dogWalk == null)
                return NotFound();

            Message message = new Message
            {
                Text = model.Text,
                IsImportant = model.IsImportant,
                CreatedAt = DateTime.Now,
                DogWalkId = dogWalkId,
            };
            _context.Messages.Add(message);
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

        //// DELETE: api/DogWalkMessages/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDogWalkMessage(int id)
        //{
        //    var dogWalkMessage = await _context.DogWalkMessages.FindAsync(id);
        //    if (dogWalkMessage == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DogWalkMessages.Remove(dogWalkMessage);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DogWalkMessageExists(int id)
        //{
        //    return _context.DogWalkMessages.Any(e => e.DogWalkMessageId == id);
        //}
    }
}
