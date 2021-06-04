﻿using System;
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
    public class CalificationsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public CalificationsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/Califications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calification>>> GetCalification()
        {
            return await _context.Calification.ToListAsync();
        }

        // GET: api/Califications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calification>> GetCalification(int id)
        {
            var calification = await _context.Calification.FindAsync(id);

            if (calification == null)
            {
                return NotFound();
            }

            return calification;
        }

        // PUT: api/Califications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalification(int id, Calification calification)
        {
            if (id != calification.CalificationId)
            {
                return BadRequest();
            }

            _context.Entry(calification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificationExists(id))
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

        // POST: api/Califications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calification>> PostCalification(Calification calification)
        {
            _context.Calification.Add(calification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalification", new { id = calification.CalificationId }, calification);
        }

        // DELETE: api/Califications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalification(int id)
        {
            var calification = await _context.Calification.FindAsync(id);
            if (calification == null)
            {
                return NotFound();
            }

            _context.Calification.Remove(calification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificationExists(int id)
        {
            return _context.Calification.Any(e => e.CalificationId == id);
        }
    }
}