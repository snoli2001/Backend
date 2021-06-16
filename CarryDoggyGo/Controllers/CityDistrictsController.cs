using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.District;

namespace CarryDoggyGo.Controllers
{
    [Route("api/City/")]
    [ApiController]
    public class CityDistrictsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public CityDistrictsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/CitiyDistricts/5
        [HttpGet("{Cityid}/districts")]
        public async Task<IActionResult> GetDistrictsByCityId (int Cityid)
        {
            IEnumerable<District> districtList = await _context.Districts.ToListAsync();

            var districtListByCityId = districtList.ToList().Where(d => d.CityId == Cityid);

            if (districtListByCityId.Count() > 0)
            {
                return Ok(districtListByCityId.Select(d => new DistrictModel
                {
                      DistrictId = d.DistrictId,
                      Name = d.Name,
                      CityId = d.CityId
                }));
            }
            else
            {
                return Ok("La ciudad no ha registrado ningun distrito todavia");
            }
        }

        // POST: api/CitiyDistricts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{Cityid}/districts")]
        public async Task<IActionResult> Post(int Cityid, [FromBody] CreateDistrictModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            City city = await _context.Cities.FindAsync(Cityid);

            if (city == null)
                return NotFound();

            District district = new District
            {
                Name = model.Name,
                CityId = Cityid,
                City = city
            };
            _context.Districts.Add(district);
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

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.CityId == id);
        }
    }
}
