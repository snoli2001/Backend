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
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DistrictsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/Districts
        [HttpGet]
        public async Task<IEnumerable<DistrictModel>> GetDistricts()
        {
            var DistrictList = await _context.Districts.ToListAsync();

            return DistrictList.Select(d => new DistrictModel
            {
                DistrictId = d.DistrictId,
                Name = d.Name,
                CityId = d.CityId
            });
        }

        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistrictById(int id)
        {
            var District = await _context.Districts.FindAsync(id);

            if (District == null)
                return NotFound();

            return Ok(new DistrictModel
            {
                DistrictId = District.DistrictId,
                Name = District.Name,
                CityId = District.CityId
            });
        }

        private bool DistrictExists(int id)
        {
            return _context.Districts.Any(e => e.DistrictId == id);
        }
    }
}
