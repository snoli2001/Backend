using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models;
using CarryDoggyGo.Models.PaymentType;

namespace CarryDoggyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public PaymentTypesController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/PaymentTypes
        [HttpGet]
        public async Task<IEnumerable<PaymentTypeModel>> GetPaymentTypes()
        {
            var paymentTypeList = await _context.PaymentTypes.ToListAsync();

            return paymentTypeList.Select(d => new PaymentTypeModel
            {
                PaymentTypeId = d.PaymentTypeId,
                Name = d.Name,
            });

        }

        // GET api/PaymentTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentTypeById(int id)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(id);

            if (paymentType == null)
                return NotFound();

            return Ok(new PaymentTypeModel
            {
                PaymentTypeId = paymentType.PaymentTypeId,
                Name = paymentType.Name,
            });
        }

        // POST api/PaymentTypes
        [HttpPost]
        public async Task<IActionResult> PostPaymentType([FromBody] CreatePaymentTypeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PaymentType paymentType = new PaymentType
            {
                Name = model.Name,
            };
            _context.PaymentTypes.Add(paymentType);
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

        // PUT api/PaymentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentType(int id, [FromBody] UpdatePaymentTypeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var paymentType = await _context.PaymentTypes.FirstOrDefaultAsync(d => d.PaymentTypeId == id);

            if (paymentType == null)
                return NotFound();



            paymentType.Name = model.Name;

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

        // DELETE api/<PaymentTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPaymentType = await _context.PaymentTypes.FindAsync(id);
            if (existingPaymentType == null)
                return NotFound();

            try
            {
                _context.Remove(existingPaymentType);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingPaymentType);
        }
    }
}
