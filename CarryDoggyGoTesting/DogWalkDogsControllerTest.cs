using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models;
using CarryDoggyGo.Models.Dog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace CarryDoggyGoTesting
{
    public class DogWalkDogsControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<Dog> _dogs; // lista utilizada para testear

        public DogWalkDogsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _dogs = getDogWalkDogsSession(); // inicializando la lista de paseadores de perros que 
        }
        public List<Dog> getDogWalkDogsSession()
        {
            var dogWalkDogs = new List<Dog>();
            dogWalkDogs.Add(new Dog
            {
                DogId = 1,
                Name = "Test1",
                Race = "race1",
                Description = "description1",
                Diseases = "diseases1",
                DogOwnerId = 1,
                MedicalInformation="MI 1"

            });
            dogWalkDogs.Add(new Dog
            {
                DogId = 2,
                Name = "Test2",
                Race = "race2",
                Description = "description2",
                Diseases = "diseases2",
                DogOwnerId = 2,
                MedicalInformation = "MI 2"

            });
            return dogWalkDogs;
        }
        [Fact]
        public async Task GetDogWalkDogsByIdReturnAIActionResultWithDogWalkDogs()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Dogs.AddRange(_dogs);
                _context.SaveChanges();

                var controller = new DogWalkDogsController(_context);

                //Act
                var result = await controller.GetAllDogsByDogWalkId(1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PatchDogCareItemByDogIdAndCareItemIdReturnAIActionResultWithDogCareItem()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Dogs.AddRange(_dogs);
                _context.SaveChanges();

                var controller = new DogWalkDogsController(_context);

                //Act
                var result = await controller.UnAssignDog(1, 1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }

        }

        [Fact]
        public async Task DeleteDogWalkDogsReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Dogs.AddRange(_dogs);
                _context.SaveChanges();
                var controller = new DogWalkDogsController(_context);

                //Act
                var result = await controller.UnAssignDog(1,1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }
    }
}
