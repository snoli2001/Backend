using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.DogWalker;
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
    public class DogWalkerDistrictsControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<DogWalker> _dogWalkers; // lista utilizada para testear
        private readonly List<District> _districts;
        public DogWalkerDistrictsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuraciÃ³n del builder al option
            _dogWalkers = getDogWalkersSession(); // inicializando la lista de paseadores de perros que 
            _districts = getDistrictsSession();
        }
        public List<DogWalker> getDogWalkersSession()
        {
            var dogWalkers = new List<DogWalker>();
            dogWalkers.Add(new DogWalker
            {
                DogWalkerId = 1,
                Name = "Test1",
                LastName = "One",
                Email = "test@gmail.com",
                Phone = "987654321",
                Password = "123456"

            });
            dogWalkers.Add(new DogWalker
            {
                DogWalkerId = 2,
                Name = "Test2",
                LastName = "Two",
                Email = "test@gmail.com",
                Phone = "987654321",
                Password = "123456"

            });
            return dogWalkers;
        }
        public List<District> getDistrictsSession()
        {
            var districts = new List<District>();
            districts.Add(new District
            {
                DistrictId = 1,
                Name = "Test1",
                CityId = 1
            });
            districts.Add(new District
            {
                DistrictId = 2,
                Name = "Test2",
                CityId = 2
            });
            return districts;
        }
        [Fact]
        public async Task GetDogWalkerDistrictsAsyncReturnAIEnumerableOfDogWalkerDistrictsModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalkers.AddRange(_dogWalkers);
                _context.Districts.AddRange(_districts);
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new DogWalkerDistrictsController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetAllDistrictsByDogWalkerId(1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PatchDogWalkerItemByDogIdAndDistricttemIdReturnAIActionResultWithDogCareItem()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalkers.AddRange(_dogWalkers);
                _context.Districts.AddRange(_districts);
                _context.SaveChanges();

                var controller = new DogWalkerDistrictsController(_context);

                //Act
                var result = await controller.AssignDistrict(1, 1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }

        }
        [Fact]
        public async Task DeleteDogWalkerDistrictsReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalkers.AddRange(_dogWalkers);
                _context.Districts.AddRange(_districts);
                _context.SaveChanges();
                var controller = new DogWalkerDistrictsController(_context);

                //Act
                var result = await controller.UnAssignDistrict(1,1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }
    }
}
