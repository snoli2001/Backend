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
    [Route("api/DogWalks/")]
    [ApiController]
    public class QualificationsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public QualificationsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/Qualifications
        //[HttpGet("{dogwalkId}/Qualifications/{locationId}")]
        [HttpGet("{dogwalkId}/Qualifications")]
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
        [HttpGet("{dogWalkId}/Qualifications/{qualificationsId}")]
        public async Task<IActionResult> GetQualificationById(int dogWalkId, int qualificationsId)
        {
            DogWalk dogWalk = await _context.DogWalks.FindAsync(dogWalkId);
            Qualification qualification = await _context.Qualifications.FindAsync(qualificationsId);

            if (dogWalk == null)
                return NotFound();

            if (qualification == null)
                return NotFound();

            return Ok(new QualificationModel
            {
                QualificationId = qualification.QualificationId,
                Starts = qualification.Starts,
                Recomendations = qualification.Recomendations,
            });

        }

        //// PUT: api/Qualifications/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQualification(int id, [FromBody] UpdateQualificationModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    if (id <= 0)
        //        return BadRequest();

        //    var Qualification = await _context.Qualifications.FirstOrDefaultAsync(d => d.QualificationId == id);

        //    if (Qualification == null)
        //        return NotFound();

        //    Qualification.Starts = model.Starts;
        //    Qualification.Recomendations = model.Recomendations;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok(model);

        //}

        // POST: api/Qualifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{dogWalkId}/Qualifications")]
        public async Task<IActionResult> PostQualification(int dogWalkId, [FromBody] CreateQualificationModel model)
        {

            var dogWalk = await _context.DogWalks
                .Where(x => x.DogWalkId.Equals(dogWalkId))
                .ToListAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Qualification calification = new Qualification
            {
                Starts = model.Starts,
                Recomendations = model.Recomendations,
                DogWalkId = dogWalkId,

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

        //// DELETE: api/Qualifications/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQualification(int id)
        //{
        //    var existingcalification = await _context.Qualifications.FindAsync(id);
        //    if (existingcalification == null)
        //        return NotFound();

        //    try
        //    {
        //        _context.Remove(existingcalification);
        //        await _context.SaveChangesAsync();

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok(existingcalification);
        //}

        //private bool QualificationExists(int id)
        //{
        //    return _context.Qualifications.Any(e => e.QualificationId == id);
        //}
    }
}