using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models;
using CarryDoggyGo.Models.DogWalker;
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
    public class DogWalkersControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<DogWalker>_dogWalkers; // lista utilizada para testear

        public DogWalkersControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _dogWalkers = getDogWalkersSession(); // inicializando la lista de paseadores de perros que 
        }
        
        [Fact]
        public async Task GetDogWalkerAsyncReturnAIEnumerableOfDogWalkerModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalkers.AddRange(_dogWalkers); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new DogWalkersController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetDogWalkers(); // llamando nuestro get

                //Assert
                Assert.True(typeof(IEnumerable<DogWalkerModel>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }

        [Fact]
        public async Task GetDogWalkerByIdReturnAIActionResultWithDogWalker()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalkers.AddRange(_dogWalkers);
                _context.SaveChanges();

                var controller = new DogWalkersController(_context);

                //Act
                var result = await controller.GetDogWalkerById(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostDogWalkerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateDogWalkerModel newDogWalker = new CreateDogWalkerModel
                {
                    Name            = "test",
                    LastName        = "test",
                    Phone           = "987654321",
                    Email           = "test@test.com",
                    Description     = "soy una descripcion",
                    PaymentAmount   = 40
                };
                var controller = new DogWalkersController(_context);

                //Act
                var result = await controller.PostDogWalker(newDogWalker);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PutDogWalkerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalkers.AddRange(_dogWalkers);
                _context.SaveChanges();
                UpdateDogWalkerModel updateDogWalker = new UpdateDogWalkerModel
                {
                    Name = "test",
                    LastName = "test",
                    Phone = "987654321",
                    Password = "12345678",
                    Description = "soy una descripcion",
                    PaymentAmount = 50
                };
                var controller = new DogWalkersController(_context);

                //Act
                var result = await controller.PutDogWalker(1,updateDogWalker);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task DeleteDogWalkerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalkers.AddRange(_dogWalkers);
                _context.SaveChanges();
                var controller = new DogWalkersController(_context);

                //Act
                var result = await controller.Delete(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
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
    }
    
}
