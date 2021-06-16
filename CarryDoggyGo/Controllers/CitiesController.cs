using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.City;

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public CitiesController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<IEnumerable<CityModel>> GetCities()
        {
            var CityList = await _context.Cities.ToListAsync();

            return CityList.Select(d => new CityModel
            {
                CityId = d.CityId,
                Name = d.Name
            });
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var City = await _context.Cities.FindAsync(id);

            if (City == null)
                return NotFound();

            return Ok(new CityModel
            {
                CityId = City.CityId,
                Name = City.Name
            });
        }

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCity([FromBody] CreateCityModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            City city = new City
            {
                Name = model.Name
            };
            _context.Cities.Add(city);
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
