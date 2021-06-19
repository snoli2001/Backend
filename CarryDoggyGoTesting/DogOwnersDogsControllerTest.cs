using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.CaresItem;
using CarryDoggyGo.Models.Dog;
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
    public class DogOwnersDogsControllerTest
    {

        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<Dog> _dogownerdogs; // lista utilizada para testear

        public DogOwnersDogsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuraciÃ³n del builder al option
            _dogownerdogs = getDogOwnerDogsSession(); // inicializando la lista de paseadores de perros que 
        }

        [Fact]
        public async Task GetDogsByDogOwnerIdReturnAIActionResultWithDogOwnersDogs()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Dogs.AddRange(_dogownerdogs);
                _context.SaveChanges();

                var controller = new DogOwnersDogsController(_context);

                //Act
                var result = await controller.GetDogsByDogOnwerId(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostDogsByDogownerIdReturnAnOkObjectResult()
        {
            //DogOwner dogOwner = await _context.DogOwners.FindAsync(1);
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateDogModel newDog = new CreateDogModel
                {
                    Name = "Test1",
                    Race = "Race1",
                    Description = "una descripcion",
                    Diseases = "Disease1",
                    MedicalInformation = "MedicalInformation1",
                };
                var controller = new DogOwnersDogsController(_context);

                //Act
                var result = await controller.Post(1, newDog);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        public List<Dog> getDogOwnerDogsSession()
        {
            var dogownerdogs = new List<Dog>();

            dogownerdogs.Add(new Dog
            {
                DogId = 1,
                Name = "Name1",
                Race = "Race1",
                Description = "una descripcion",
                Diseases = "Disease1",
                DogOwnerId = 1,
                MedicalInformation = "MedicalInformation1",
            });
            dogownerdogs.Add(new Dog
            {
                DogId = 2,
                Name = "Name2",
                Race = "Race2",
                Description = "una descripcion 2",
                Diseases = "Disease2",
                DogOwnerId = 2,
                MedicalInformation = "MedicalInformation2",
            });
            return dogownerdogs;
        }
    }
}