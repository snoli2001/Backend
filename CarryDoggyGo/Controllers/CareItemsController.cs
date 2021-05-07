using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Models.CaresItem;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareItemsController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public CareItemsController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/CareItems
        [HttpGet]
        public async Task<IEnumerable<CaresItemModel>> GetCareItems()
        {
            var CareItemList = await _context.CareItems.ToListAsync();

            return CareItemList.Select(d => new CaresItemModel
            {
                CareItemId = d.CareItemId,
                Name = d.Name,
                Description = d.Description,
                
            });

        }

        // GET: api/CareItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaresItemById(int id)
        {
            var Caresitem = await _context.CareItems.FindAsync(id);

            if (Caresitem == null)
                return NotFound();

            return Ok(new CaresItemModel
            {
                CareItemId = Caresitem.CareItemId,
                Name = Caresitem.Name,
                Description = Caresitem.Description,
            });
        }
        // PUT: api/CareItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareItem(int id, [FromBody] UpdateCareItemModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var Careitem = await _context.CareItems.FirstOrDefaultAsync(d => d.CareItemId == id);

            if (Careitem == null)
                return NotFound();

            Careitem.Name = model.Name;
            Careitem.Description = model.Description;

            

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


        // POST: api/CareItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        

        public async Task<IActionResult> PostCareItem([FromBody] CreateCareitemModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CareItem careItem = new CareItem
            {
                
                Name = model.Name,
                
                Description = model.Description,
                
            };
            _context.CareItems.Add(careItem);
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


        // DELETE: api/CareItems/5
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> Delete(int id)
        {
            var existingcareitem = await _context.CareItems.FindAsync(id);
            if (existingcareitem == null)
                return NotFound();

            try
            {
                _context.Remove(existingcareitem);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingcareitem);
        }
        private bool CareItemExists(int id)
        {
            return _context.CareItems.Any(e => e.CareItemId == id);
        }
    }
}
