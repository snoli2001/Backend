using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Location;

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public LocationsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<IEnumerable<LocationModel>> GetLocations()
        {
            var LocationList = await _context.Locations.ToListAsync();

            return LocationList.Select(d => new LocationModel
            {
                LocationId = d.LocationId,
                Address = d.Address,
                NumX = d.NumX,
                NumY = d.NumY,
                //DistrictId = d.DistrictId
            });
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var Location = await _context.Locations.FindAsync(id);

            if (Location == null)
                return NotFound();

            return Ok(new LocationModel
            {
                LocationId = Location.LocationId,
                Address = Location.Address,
                NumX = Location.NumX,
                NumY = Location.NumY,
                //DistrictId = Location.DistrictId
            });
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, [FromBody] UpdateLocationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var location = await _context.Locations.FirstOrDefaultAsync(d => d.LocationId == id);

            if (location == null)
                return NotFound();



            location.Address = model.Address;
            location.NumX = model.NumX;
            location.NumY = model.NumY;

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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostLocation([FromBody] CreateLocationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Location location = new Location
            {
                Address = model.Address,
                NumX = model.NumX,
                NumY = model.NumY
            };
            _context.Locations.Add(location);
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

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var existingLocation = await _context.Locations.FindAsync(id);
            if (existingLocation == null)
                return NotFound();

            try
            {
                _context.Remove(existingLocation);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingLocation);
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
