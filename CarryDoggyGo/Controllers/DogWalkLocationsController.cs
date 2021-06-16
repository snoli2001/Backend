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
    [Route("api/DogWalk/")]
    [ApiController]
    public class DogWalkLocationsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogWalkLocationsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        [HttpPatch("{dogwalkId}/Location/{locationId}")]
        public async Task<IActionResult> AssignLocation(int dogwalkId, int locationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogWalk dogwalk = await _context.DogWalks.FindAsync(dogwalkId);
            Location location = await _context.Locations.FindAsync(locationId);

            if (dogwalk == null)
                return NotFound();

            if (location == null)
                return NotFound();

            DogWalkLocation newAssign = new DogWalkLocation
            {
                DogWalkId = dogwalkId,
                LocationId = locationId,
                DateRegister = DateTime.Now
            };
            //dog.DogCareItems.Add(newAssign);

            await _context.DogWalkLocations.AddAsync(newAssign);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // GET: api/DogWalkLocations/5
        [HttpGet("{dogwalkid}/locations")]
        public async Task<IActionResult> GetLocations(int dogwalkid)
        {
            DogWalk dogwalk = await _context.DogWalks.FindAsync(dogwalkid);
            var locationList = await _context.Locations.ToListAsync();

            if (dogwalk == null)
                return NotFound();

            var results = await _context.DogWalkLocations
                .Where(dwl => dwl.DogWalkId == dogwalkid)
                .Include(dwl => dwl.Location)
                .Include(dwl => dwl.DogWalk)
                .Select(dwl => dwl.Location)
                .ToListAsync();

            var resources = results.Select(result => new LocationModel
            {
                LocationId = result.LocationId,
                Address = result.Address,
                NumX = result.NumX,
                NumY = result.NumY,
                //DistrictId = result.DistrictId
            });
            return Ok(resources);
        }

        private bool DogWalkLocationExists(int id)
        {
            return _context.DogWalkLocations.Any(e => e.DogWalkId == id);
        }
    }
}
