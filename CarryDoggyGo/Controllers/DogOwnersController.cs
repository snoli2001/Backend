using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Dog;
using CarryDoggyGo.Models.DogOwner;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogOwnersController : ControllerBase
    {
        public DbContextCarryDoggyGo _context;

        public DogOwnersController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/<DogOwnersController>
        [HttpGet]
        public async Task<IEnumerable<DogOwnerModel>> Get()
        {
            var dogOwnerList = await _context.DogOwners.ToListAsync();

            // dogOwner -> dogOwnerModel
            return dogOwnerList.Select(dogOwner => new DogOwnerModel
            {
                DogOnwerId = dogOwner.DogOwnerId,
                Name = dogOwner.Name,
                LastName = dogOwner.LastName,
                Phone = dogOwner.Phone,
                Email = dogOwner.Email,
                Address = dogOwner.Address,
                //by gsinuiri
                DistrictId = dogOwner.DistrictId
            });
        }

        // GET api/<DogOwnersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dogOnwner = await _context.DogOwners.FindAsync(id);

            if (dogOnwner == null)
                return NotFound();

            return Ok(new DogOwnerModel
            {
                DogOnwerId = dogOnwner.DogOwnerId,
                Name = dogOnwner.Name,
                LastName = dogOnwner.LastName,
                Phone = dogOnwner.Phone,
                Email = dogOnwner.Email,
                Address = dogOnwner.Address,
                //by gsinuiri
                DistrictId = dogOnwner.DistrictId
            });
        }
     

        // POST api/<DogOwnersController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateDogOwnerModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DogOwner dogOwner = new DogOwner
            {
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone,
                Address = model.Address,
                //by gsinuiri
                DistrictId = model.DistrictId
            };
            _context.DogOwners.Add(dogOwner);
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

      
      

        // PUT api/<DogOwnersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogOwner(int id, [FromBody] UpdateDogownerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var dogowner = await _context.DogOwners.FirstOrDefaultAsync(d => d.DogOwnerId == id);

            if (dogowner == null)
                return NotFound();



            dogowner.Name = model.Name;
            dogowner.LastName = model.LastName;
            dogowner.Password = model.Password;
            dogowner.Phone = model.Phone;
            dogowner.Address = model.Address;

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


        // DELETE api/<DogOwnersController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var existingDogowner = await _context.DogOwners.FindAsync(id);
            if (existingDogowner == null)
                return NotFound();

            try
            {
                _context.Remove(existingDogowner);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingDogowner);
        }

    }
}
