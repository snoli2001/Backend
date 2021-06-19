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
    public class DistrictsControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<District> _districts; // lista utilizada para testear

        public DistrictsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _districts = getDistrictsSession(); // inicializando la lista de paseadores de perros que 
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
        public async Task GetDistrictsAsyncReturnAIEnumerableOfDistrictsModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Districts.AddRange(_districts); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new DistrictsController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetDistricts(); // llamando nuestro get

                //Assert
                Assert.False(typeof(IEnumerable<District>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }

        [Fact]
        public async Task GetDistrictsByIdReturnAIActionResultWithDistricts()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Districts.AddRange(_districts);
                _context.SaveChanges();

                var controller = new DistrictsController(_context);

                //Act
                var result = await controller.GetDistrictById(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

    }
}
