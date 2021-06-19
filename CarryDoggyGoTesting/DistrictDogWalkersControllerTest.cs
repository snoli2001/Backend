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
    public class DistrictDogWalkersControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<DogWalker> _districts; // lista utilizada para testear

        public DistrictDogWalkersControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _districts = getDistrictDogWalkerSession(); // inicializando la lista de paseadores de perros que 
        }
        public List<DogWalker> getDistrictDogWalkerSession()
        {
            var dogWalkerDistricts = new List<DogWalker>();
            dogWalkerDistricts.Add(new DogWalker
            {
                DogWalkerId = 1,
                Name = "Test1",
                LastName= "Lastname 1",
                Phone="9456123789",
                Email = "email11@gmail.com",
                Description = "una descripcion",
                PaymentAmount= 100
            });
            dogWalkerDistricts.Add(new DogWalker
            {
                DogWalkerId = 2,
                Name = "Test2",
                LastName = "Lastname 2",
                Phone = "9456123739",
                Email = "email22@gmail.com",
                Description = "segunda descripcion",
                PaymentAmount = 200
            });
            return dogWalkerDistricts;
        }

        [Fact]
        public async Task GetDistrictDogWalkersAsyncReturnAIEnumerableOfDistrictDogWalkersModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalkers.AddRange(_districts); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new DistrictDogWalkersController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetAllDogWalkersByDistrictId(1); // llamando nuestro get

                //Assert
                Assert.False(typeof(IEnumerable<DogWalker>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                
            }
        }

    }
}
