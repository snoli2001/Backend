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

namespace CarryDoggyGo.Controllers
{
    [Route("api/Districts")]
    [ApiController]
    public class DistrictDogWalkersController : ControllerBase
    {
        private readonly DbContextCarryDoggyGo _context;

        public DistrictDogWalkersController(DbContextCarryDoggyGo context)
        {
            _context = context;
        }

        // GET: api/Districts
        [HttpGet("{districtId}/DogWalkers")]
        public async Task<IEnumerable<DogWalkerModel>> GetAllDogWalkersByDistrictId(int districtId)
        {
            var dogWalkerDistricts = await _context.DogWalkerDistricts
                .Include(pt => pt.DogWalker)
                .Include(pt => pt.District)
                .Where(x => x.DogWalkerkId.Equals(districtId))
                .ToListAsync();

            if (dogWalkerDistricts == null)
                return null;

            return dogWalkerDistricts.Select(x => new DogWalkerModel
            {
                DogWlakerId = x.DogWalkerkId,
                Name = x.DogWalker.Name,
                LastName = x.DogWalker.LastName,
                Phone = x.DogWalker.Phone,
                Email = x.DogWalker.Email,
                Description = x.DogWalker.Description,
                PaymentAmount = x.DogWalker.PaymentAmount,
            });
        }
    }
}
