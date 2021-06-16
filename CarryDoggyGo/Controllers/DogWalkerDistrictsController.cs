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
    [Route("api/DogWalkers")]
    [ApiController]
    public class DogWalkerDistrictsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogWalkerDistrictsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/DogWalkers
        [HttpGet("{dogWalkerId}/Districts")]
        public async Task<IEnumerable<DistrictModel>> GetAllDistrictsByDogWalkerId(int dogWalkerId)
        {
            var dogWalkerDistricts = await _context.DogWalkerDistricts
                .Include(pt => pt.DogWalker)
                .Include(pt => pt.District)
                .Where(x=>x.DogWalkerkId.Equals(dogWalkerId))
                .ToListAsync();

            if (dogWalkerDistricts == null)
                return null;

            return dogWalkerDistricts.Select(x => new DistrictModel
            {
                DistrictId = x.DistrictId,
                Name = x.District.Name,
                CityId = x.District.CityId
            });
        }


        [HttpPatch("{dogWalkerId}/Districts/{districtId}")]
        public async Task<IActionResult> AssignDistrict(int dogWalkerId, int districtId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogWalker dogWalker = await _context.DogWalkers.FindAsync(dogWalkerId);
            District district = await _context.Districts.FindAsync(districtId);

            if (dogWalker == null)
                return NotFound();

            if (district == null)
                return NotFound();

            DogWalkerDistrict newAssign = new DogWalkerDistrict
            {
                DogWalkerkId = dogWalkerId,
                DistrictId = districtId,
            };

            await _context.DogWalkerDistricts.AddAsync(newAssign);
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


        [HttpDelete("{dogWalkerId}/Districts/{districtId}")]
        public async Task<IActionResult> UnAssignDistrict(int dogWalkerId, int districtId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogWalkerDistrict dogWalkerDistrict = await _context.DogWalkerDistricts
                .Where(x => x.DogWalkerkId.Equals(dogWalkerId))
                .Where(y => y.DistrictId.Equals(districtId))
                .FirstOrDefaultAsync();

            if (dogWalkerDistrict == null)
                return NotFound();

            try
            {
                _context.Remove(dogWalkerDistrict);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
