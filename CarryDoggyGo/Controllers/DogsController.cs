using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Dog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        private readonly DbContextCarryDoggyGo _context;

        public DogsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<DogModel>> GetDogs()
        {
            var dogList = await _context.Dogs.ToListAsync();

            return dogList.Select(d => new DogModel
            {
                DogId = d.DogId,
                Name = d.Name,
                Description = d.Description,
                Diseases = d.Diseases,
                DogOwnerId = d.DogOwnerId,
                Race = d.Race,
                MedicalInformation = d.MedicalInformation,
            });

        }
       
        [HttpGet("{dogId}")]
        public async Task<IActionResult> GetDogsByDogOnwerIdAndDogId(int dogId)
        {
            var dog = await _context.Dogs.FindAsync(dogId);

            if (dog == null)
                return NotFound();

                return Ok(new DogModel
                {
                    DogId = dog.DogId,
                    Name = dog.Name,
                    Description = dog.Description,
                    Diseases = dog.Diseases,
                    DogOwnerId = dog.DogOwnerId,
                    Race = dog.Race,
                    MedicalInformation = dog.MedicalInformation,
                });
        }
       
        // PUT api/<DogsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DogsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
