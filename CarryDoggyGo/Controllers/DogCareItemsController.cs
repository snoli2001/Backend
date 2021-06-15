using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.CaresItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Controllers
{
    [Route("api/dogs/")]
    [ApiController]
    public class DogCareItems : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogCareItems(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        [HttpPatch("{dogId}/CareItems/{careItemId}")]
        public async Task<IActionResult> AssignItems(int dogId, int careItemId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Dog dog = await _context.Dogs.FindAsync(dogId);
            CareItem careItem = await _context.CareItems.FindAsync(careItemId);

            if (dog == null)
                return NotFound();

            if (careItem == null)
                return NotFound();

            DogCareItem newAssign = new DogCareItem
            {
                CareItemId = careItemId,
                DogId = dogId,
            };
            //dog.DogCareItems.Add(newAssign);

            await _context.DogCareItems.AddAsync(newAssign);
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


        [HttpGet("{dogId}/CareItems")]
        public async Task<IActionResult> GetCareItems(int dogId)
        {
            Dog dog = await _context.Dogs.FindAsync(dogId);
            var careItemList = await _context.DogCareItems.ToListAsync();

            if (dog == null)
                return NotFound();

            var results = await _context.DogCareItems
                .Where(dci => dci.DogId == dogId)
                .Include(dci => dci.CareItem)
                .Include(dci => dci.Dog)
                .Select(dci => dci.CareItem)
                .ToListAsync();

            var resources = results.Select(result => new CaresItemModel
            {
                CareItemId = result.CareItemId,
                Name = result.Name,
                Description = result.Description,
            });
            return Ok(resources);
        }
    }
}