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
    [Route("api/DogOwners/")]
    [ApiController]
    public class DogOwnersDogsController : ControllerBase
    {
        public DbContextCarryDoggyGo _context;

        public DogOwnersDogsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }
        [HttpGet("{dogOwnerId}/dogs")]
        public async Task<IActionResult> GetDogsByDogOnwerId(int dogOwnerId)
        {
            IEnumerable<Dog> dogList = await _context.Dogs.ToListAsync();

            var dogListByDogOwnerId = dogList.ToList().Where(d => d.DogOwnerId == dogOwnerId);

            if (dogListByDogOwnerId.Count() > 0)
            {
                return Ok(dogListByDogOwnerId.Select(d => new DogModel
                {
                    DogId = d.DogId,
                    Name = d.Name,
                    Description = d.Description,
                    Diseases = d.Diseases,
                    DogOwnerId = d.DogOwnerId,
                    Race = d.Race,
                    MedicalInformation = d.MedicalInformation,
                }));
            }
            else
            {
                return Ok(dogListByDogOwnerId);
            }
        }

        [HttpPost("{dogOwnerId}/dogs")]
        public async Task<IActionResult> Post(int dogOwnerId, [FromBody] CreateDogModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogOwner dogOwner = await _context.DogOwners.FindAsync(dogOwnerId);

            if (dogOwner == null)
                return NotFound();

            Dog dog = new Dog
            {
                Name = model.Name,
                Description = model.Description,
                Diseases = model.Diseases,
                DogOwnerId = dogOwnerId,
                Race = model.Race,
                DogOwner = dogOwner,
                MedicalInformation = model.MedicalInformation,
            };
            _context.Dogs.Add(dog);
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
    }
}
