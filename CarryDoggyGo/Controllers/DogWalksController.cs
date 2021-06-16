using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.DogWalk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DogWalksController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogWalksController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        
        [HttpGet("DogWalkers/{dogwalkerId}/DogWalks")]
        public async Task<IActionResult> GetDogWalkers(int dogwalkerId)
        {
            DogWalker dogWalker = await _context.DogWalkers.FindAsync(dogwalkerId);

            if (dogWalker == null)
                return NotFound();

            var dogWalkList = await _context.DogWalks
                .Where(d => d.DogWalkerId == dogwalkerId)
                .ToListAsync();
            

            return Ok(dogWalkList.Select(d => new DogWalkModel
            {
                DogWalkerId = d.DogWalkerId,
                //DogOwnerId = d.DogOwnerId,
                DogWalkId = d.DogWalkId,
                Hours = d.Hours,
                Address = d.Address,
                AditionalInformation = d.AditionalInformation,
                PaymentAmount = d.PaymentAmount,
                Date = d.Date,
            }));

        }

        [HttpPost("DogWalks")]
        public async Task<IActionResult> PostDogWalkers([FromBody] CreateDogWalkModel model)
        {
            //DogOwner dogOwner = await _context.DogOwners.FindAsync(dogOnwerId);


            DogWalker dogWalker = await _context.DogWalkers.FindAsync(model.DogWalkerId);

            //var dogs = await _context.Dogs
            //                .Where(d => d.DogOwnerId == dogOnwerId)
            //                .Where(d => model.dogsIds.Contains(d.DogId))
            //                .ToListAsync();


            //if (dogOwner == null)
            //    return NotFound();

            if (dogWalker == null)
                return NotFound();

            //if(dogs == null)
            //{
            //    return NotFound();
            //}

            DogWalk dogWalk = new DogWalk
            {
                DogWalkerId = model.DogWalkerId,
                //DogOwnerId = dogOnwerId,
                Hours = model.Hours,
                Address = model.Address,
                AditionalInformation = model.AditionalInformation,
                PaymentAmount = model.PaymentAmount,
                Date = model.Date,
                state = DogWalkState.TO_START,

                DistrictId = model.DistrictId,
                //TODO: no obligatorio
                //QualificationId = model.QualificationId,
                PaymentTypeId = model.PaymentTypeId,

            };

            _context.DogWalks.Add(dogWalk);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok( new DogWalkModel
            {
                DogWalkerId = model.DogWalkerId,
                //DogOwnerId = dogOnwerId,
                Hours = model.Hours,
                Address = model.Address,
                AditionalInformation = model.AditionalInformation,
                PaymentAmount = model.PaymentAmount,
                Date = model.Date,

                
            });

        }


        [HttpPatch("DogWalks/{dogwalkId}/InProgress")]
        public async Task<IActionResult> InProgressDogWalkers(int dogwalkId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dogWalk = await _context.DogWalks.FirstOrDefaultAsync(d => d.DogWalkId == dogwalkId);

            if (dogWalk == null)
                return NotFound();

            dogWalk.state = DogWalkState.IN_PROGRESS;

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


        [HttpPatch("DogWalks/{dogwalkId}/Finished")]
        public async Task<IActionResult> finishedDogWalkers(int dogwalkId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dogWalk = await _context.DogWalks.FirstOrDefaultAsync(d => d.DogWalkId == dogwalkId);

            if (dogWalk == null)
                return NotFound();

            dogWalk.state = DogWalkState.FINISHED;

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


        [HttpPatch("DogWalks/{dogwalkId}/canceled")]
        public async Task<IActionResult> canceledDogWalkers(int dogwalkId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dogWalk = await _context.DogWalks.FirstOrDefaultAsync(d => d.DogWalkId == dogwalkId);

            if (dogWalk == null)
                return NotFound();

            dogWalk.state = DogWalkState.CANCELED;

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

    }
}
