using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.CaresItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace CarryDoggyGoTesting
{
    public class DogWalkLocationsControllerTest
    {

        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<DogWalk> _dogWalks; // lista utilizada para testear
        private readonly List<Location> _locations;
        public DogWalkLocationsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuraciÃ³n del builder al option
            _dogWalks = getDogWalksSession(); // inicializando la lista de paseadores de perros que 
            _locations = getLocationsSession();
        }

        public List<DogWalk> getDogWalksSession()
        {
            var dogWalks = new List<DogWalk>();
            dogWalks.Add(new DogWalk
            {
                DogWalkerId = 1,
                DogWalkId = 1,
                Hours = 2,
                Address = "av. viru",
                AditionalInformation = "Informacion 1",
                PaymentAmount = "30",
                Date = DateTime.Now

            });
            dogWalks.Add(new DogWalk
            {
                DogWalkerId = 2,
                DogWalkId = 2,
                Hours = 3,
                Address = "av. piru",
                AditionalInformation = "Informacion 2",
                PaymentAmount = "20",
                Date = DateTime.Now
            });
            return dogWalks;
        }

        public List<Location> getLocationsSession()
        {
            var locations = new List<Location>();
            locations.Add(new Location
            {
                LocationId = 1,
                Address = "Address1",
                NumX = 1920,
                NumY = 1080
            });
            locations.Add(new Location
            {
                LocationId = 2,
                Address = "Address2",
                NumX = 1080,
                NumY = 1920
            });
            return locations;
        }

        [Fact]
        public async Task PatchDogCareItemByDogIdAndCareItemIdReturnAIActionResultWithDogCareItem()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalks.AddRange(_dogWalks);
                _context.Locations.AddRange(_locations);
                _context.SaveChanges();

                var controller = new DogWalkLocationsController(_context);

                //Act
                var result = await controller.AssignLocation(1, 1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }

        }
        [Fact]
        public async Task GetDogWalkLocationsByIdReturnAIActionResultWithDogWakLocations()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalks.AddRange(_dogWalks);
                _context.Locations.AddRange(_locations);
                _context.SaveChanges();

                var controller = new DogWalkLocationsController(_context);

                //Act
                var result = await controller.GetLocations(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

    }
}
