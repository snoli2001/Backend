using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
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
    public class DogsControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<Dog> _dogs; // lista utilizada para testear

        public DogsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _dogs = getDogSession(); // inicializando la lista de paseadores de perros que 

        }
        public List<Dog> getDogSession()
        {
            var dogs = new List<Dog>();
            dogs.Add(new Dog
            {
                DogId = 1,
                Name = "Lucho",
                Race = "labrador",
                Description = "descripcion 1",
                DogOwnerId=1,
                Diseases= "Moquillo",
                MedicalInformation="El perro sufre de moquillo, requiere atención personalizada"
            });
            dogs.Add(new Dog
            {
                DogId = 2,
                Name = "Pepe",
                Race = "pitbull",
                Description = "descripcion 2",
                DogOwnerId=2,
                Diseases = "Rabia",
                MedicalInformation = "El perro sufre de Rabia, requiere atención personalizada"
            });
            return dogs;
        }
        //1
        [Fact]
        public async Task GetDogAsyncReturnAIEnumerableOfDogModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Dogs.AddRange(_dogs); // añadiendo la lista en la base de datos ficticia con la lista de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new DogsController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetDogs(); // llamando nuestro get

                //Assert
                Assert.True(typeof(IEnumerable<DogModel>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }
        //2
        [Fact]
        public async Task GetDogByIdReturnAIActionResultWithDog()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Dogs.AddRange(_dogs);
                _context.SaveChanges();

                var controller = new DogsController(_context);

                //Act
                var result = await controller.GetDogsByDogOnwerIdAndDogId(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }
        
        //3
        [Fact]
        public async Task PutDogsReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Dogs.AddRange(_dogs);
                _context.SaveChanges();
                UpdateDogModel updateDogModel = new UpdateDogModel
                {
                    Name = "Lucho",
                    Description = " descripcion 3",
                    Race = "pitbull",
                    Diseases = "Rabia",
                    MedicalInformation = "El perro sufre de Rabia, requiere atención personalizada"
                };
                var controller = new DogsController(_context);

                //Act
                var result = await controller.PutDog(1, updateDogModel);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task DeleteDogsReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Dogs.AddRange(_dogs);
                _context.SaveChanges();
                var controller = new DogsController(_context);

                //Act
                var result = await controller.Delete(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

    }

}
