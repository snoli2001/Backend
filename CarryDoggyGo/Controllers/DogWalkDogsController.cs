using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Dog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Controllers
{
    [Route("api/DogWalks")]
    [ApiController]
    public class DogWalkDogsController : ControllerBase
    {

        private readonly DbContextCarryDoggyGo _context;

        public DogWalkDogsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/DogWalks
        [HttpGet("{dogWalkId}/Dogs")]
        public async Task<IEnumerable<DogModel>> GetAllDogsByDogWalkId(int dogWalkId)
        {
            var dogWalkDogs = await _context.DogWalkDogs
                .Include(pt => pt.DogWalk)
                .Include(pt => pt.Dog)
                .Where(x => x.DogWalkId.Equals(dogWalkId))
                .ToListAsync();

            if (dogWalkDogs == null)
                return null;

            return dogWalkDogs.Select(x => new DogModel
            {
                DogId = x.DogId,
                Name = x.Dog.Name,
                Race = x.Dog.Race,
                Description = x.Dog.Description,
                Diseases = x.Dog.Diseases,
                DogOwnerId = x.Dog.DogOwnerId,
                MedicalInformation = x.Dog.MedicalInformation,
            });
        }

        [HttpPatch("{dogWalkId}/Dogs/{dogId}")]
        public async Task<IActionResult> AssignDog(int dogWalkId, int dogId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogWalk dogWalk = await _context.DogWalks.FindAsync(dogWalkId);
            Dog dog = await _context.Dogs.FindAsync(dogId);

            if (dogWalk == null)
                return NotFound();

            if (dog == null)
                return NotFound();

            DogWalkDog newAssign = new DogWalkDog
            {
                DogWalkId = dogWalkId,
                DogId = dogId,
            };

            await _context.DogWalkDogs.AddAsync(newAssign);
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


        [HttpDelete("{dogWalkId}/Dogs/{dogId}")]
        public async Task<IActionResult> UnAssignDog(int dogWalkId, int dogId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogWalkDog dogWalkDog = await _context.DogWalkDogs
                .Where(x => x.DogWalkId.Equals(dogWalkId))
                .Where(y => y.DogId.Equals(dogId))
                .FirstOrDefaultAsync();

            if (dogWalkDog == null)
                return NotFound();

            try
            {
                _context.Remove(dogWalkDog);
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
