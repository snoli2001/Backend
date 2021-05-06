using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models;
using CarryDoggyGo.Models.DogWalker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")] //localhost:8080/api/DogWalkers
    [ApiController]
    public class DogWalkersController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogWalkersController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/DogWalkers
        [HttpGet]
        public async Task<IEnumerable<DogWalkerModel>> GetDogWalkers()
        {
            var dogWalkerList = await _context.DogWalkers.ToListAsync();


            return dogWalkerList.Select(d => new DogWalkerModel
            {
                DogWlakerId = d.DogWalkerId,
                Name = d.Name,
                LastName = d.LastName,
                Phone = d.Phone,
                Email = d.Email,
                Description = d.Description,
                PaymentAmount = d.PaymentAmount
            });

        }

        // GET api/DogWalkers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDogWalkerById(int id)
        {
            var dogWalker = await _context.DogWalkers.FindAsync(id);

            if (dogWalker == null)
                return NotFound();

            return Ok(new DogWalkerModel
            {
                DogWlakerId = dogWalker.DogWalkerId,
                Name = dogWalker.Name,
                LastName = dogWalker.LastName,
                Phone = dogWalker.Phone,
                Email = dogWalker.Email,
                Description = dogWalker.Description,
                PaymentAmount = dogWalker.PaymentAmount
            });
        }

        // POST api/DogWalkers
        [HttpPost]
        public async Task<IActionResult> PostDogWalker([FromBody] CreateDogWalkerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogWalker dogWalker = new DogWalker
            {
                Name = model.Name,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                Password = model.Password,
                Description = model.Description,
                PaymentAmount = model.PaymentAmount
            };
            _context.DogWalkers.Add(dogWalker);
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

        // PUT api/DogWalkers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogWalker(int id, [FromBody] UpdateDogWalkerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var dogWalker = await _context.DogWalkers.FirstOrDefaultAsync(d => d.DogWalkerId == id);

            if (dogWalker == null)
                return NotFound();



            dogWalker.Name = model.Name;
            dogWalker.LastName = model.LastName;
            dogWalker.Phone = model.Phone;
            dogWalker.Password = model.Password;
            dogWalker.Description = model.Description;
            dogWalker.PaymentAmount = model.PaymentAmount;

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

        // DELETE api/<DogWalkerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingDogWalker = await _context.DogWalkers.FindAsync(id);
            if (existingDogWalker == null)
                return NotFound();

            try
            {
                _context.Remove(existingDogWalker);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingDogWalker);
        }
    }
}
