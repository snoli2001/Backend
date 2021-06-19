using CarryDoggyGo.Data;
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
    [Route("api/DogOwners")]
    [ApiController]
    public class DogOwnerDogWalksController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DogOwnerDogWalksController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/Districts
        [HttpGet("{dogOwnerId}/DogWalks")]
        public async Task<IEnumerable<DogWalkModel>> GetAllDogWalksByDogOwnerId(int dogOwnerId)
        {
            var dogWalkDogs = await _context.DogWalkDogs
                .Include(pt => pt.DogWalk)
                .Include(pt => pt.Dog)
                .Where(x => x.Dog.DogOwnerId.Equals(dogOwnerId))
                .ToListAsync();

            if (dogWalkDogs == null)
                return null;

            return dogWalkDogs.Select(x => new DogWalkModel
            {
                DogWalkId = x.DogWalkId,
                Hours = x.DogWalk.Hours,
                AditionalInformation = x.DogWalk.AditionalInformation,
                PaymentAmount = x.DogWalk.PaymentAmount,
                Qualification = x.DogWalk.Qualification,
                DogWalkerId = x.DogWalk.DogWalkerId,
                Date = x.DogWalk.Date,
                Address = x.DogWalk.PaymentAmount,
            });
        }
    }
}
