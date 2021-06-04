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
        public async Task<IActionResult> PutDog(int id, [FromBody] UpdateDogModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var dog = await _context.Dogs.FirstOrDefaultAsync(d => d.DogId == id);

            if (dog == null)
                return NotFound();



            dog.Name = model.Name;
            dog.Race = model.Race;
            dog.Description = model.Description;
            dog.Diseases = model.Diseases;
            dog.MedicalInformation = model.MedicalInformation;

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

        // DELETE api/<DogsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingDog = await _context.Dogs.FindAsync(id);
            if (existingDog == null)
                return NotFound();

            try
            {
                _context.Remove(existingDog);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingDog);
        }
    }
}
