using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Report;

namespace CarryDoggyGo.Controllers
{
    [Route("api/DogWalks/")]
    [ApiController]
    public class DogWalkReportsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogWalkReportsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        //// GET: api/DogWalkReports
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DogWalkReport>>> GetDogWalkReports()
        //{
        //    return await _context.DogWalkReports.ToListAsync();
        //}

        // GET: api/DogWalkReports/5
        [HttpGet("{dogWalkId}/Reports")]
        public async Task<ActionResult<Report>> GetDogWalkReport(int dogWalkId)
        {
            IEnumerable<Report> dogList = await _context.Reports.ToListAsync();

            var dogWalkReportListByDogWalkId = dogList.ToList().Where(d => d.DogWalkId == dogWalkId);

            if (dogWalkReportListByDogWalkId.Count() > 0)
            {
                return Ok(dogWalkReportListByDogWalkId.Select(d => new ReportModel
                {
                    ReportId = d.ReportId,
                    Description = d.Description,
                    DogWalkId = d.DogWalkId,
                }));
            }
            else
            {
                return Ok("No hay reporte(s) para el dueño del perro.");
            }
        }

        //// PUT: api/DogWalkReports/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDogWalkReport(int id, DogWalkReport dogWalkReport)
        //{
        //    if (id != dogWalkReport.DogWalkReportId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dogWalkReport).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DogWalkReportExists(id))
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

        // POST: api/DogWalkReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{dogWalkId}/Reports")]
        public async Task<ActionResult<Report>> PostDogWalkReport(int dogWalkId, [FromBody] CreateReportModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogWalk dogWalk = await _context.DogWalks.FindAsync(dogWalkId);

            if (dogWalk == null)
                return NotFound();

            Report report = new Report
            {
                Description = model.Description,
                DogWalkId = dogWalkId,
            };
            _context.Reports.Add(report);
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

        //// DELETE: api/DogWalkReports/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDogWalkReport(int id)
        //{
        //    var dogWalkReport = await _context.DogWalkReports.FindAsync(id);
        //    if (dogWalkReport == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DogWalkReports.Remove(dogWalkReport);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DogWalkReportExists(int id)
        //{
        //    return _context.DogWalkReports.Any(e => e.DogWalkReportId == id);
        //}
    }
}
