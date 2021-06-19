﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.QualificationModel;

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public QualificationsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/Qualifications
        [HttpGet]
        public async Task<IEnumerable<QualificationModel>> GetQualification()
        {
            var QualificationList = await _context.Qualifications.ToListAsync();

            return QualificationList.Select(c => new QualificationModel
            {
                QualificationId = c.QualificationId,
                Starts = c.Starts,
                Recomendations = c.Recomendations,
            });

        }

        // GET: api/Qualifications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQualificationById(int id)
        {
            var Qualification = await _context.Qualifications.FindAsync(id);

            if (Qualification == null)
                return NotFound();

            return Ok(new QualificationModel
            {
                QualificationId = Qualification.QualificationId,
                Starts = Qualification.Starts,
                Recomendations = Qualification.Recomendations,
            });

        }

        // PUT: api/Qualifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQualification(int id, [FromBody] UpdateQualificationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var Qualification = await _context.Qualifications.FirstOrDefaultAsync(d => d.QualificationId == id);

            if (Qualification == null)
                return NotFound();

            Qualification.Starts = model.Starts;
            Qualification.Recomendations = model.Recomendations;

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

        // POST: api/Qualifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostQualification([FromBody] CreateQualificationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Qualification calification = new Qualification
            {

                Starts = model.Starts,
                Recomendations = model.Recomendations,

            };
            _context.Qualifications.Add(calification);
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

        // DELETE: api/Qualifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualification(int id)
        {
            var existingcalification = await _context.Qualifications.FindAsync(id);
            if (existingcalification == null)
                return NotFound();

            try
            {
                _context.Remove(existingcalification);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(existingcalification);
        }

        private bool QualificationExists(int id)
        {
            return _context.Qualifications.Any(e => e.QualificationId == id);
        }
    }
}