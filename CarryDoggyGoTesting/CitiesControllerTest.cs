using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.City;
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
    public class CitiesControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<City> _cities; // lista utilizada para testear

        public CitiesControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _cities = getCitiesSession(); // inicializando la lista de paseadores de perros que 
        }

        [Fact]
        public async Task GetCitiesAsyncReturnAIEnumerableOfCitiesItemModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Cities.AddRange(_cities); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new CitiesController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetCities(); // llamando nuestro get

                //Assert
                Assert.False(typeof(IEnumerable<City>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }

        [Fact]
        public async Task GetCitiesByIdReturnAIActionResultWithCareItem()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Cities.AddRange(_cities);
                _context.SaveChanges();

                var controller = new CitiesController(_context);

                //Act
                var result = await controller.GetCityById(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostCitiesReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateCityModel newCities = new CreateCityModel
                {
                    Name = "Test1"
                };
                var controller = new CitiesController(_context);

                //Act
                var result = await controller.PostCity(newCities);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

       

        public List<City> getCitiesSession()
        {
            var cities = new List<City>();
            cities.Add(new City
            {
                CityId = 1,
                Name = "Test1"
               
            });
            cities.Add(new City
            {
                CityId = 2,
                Name = "Test2"
            });
            return cities;
        }
    }
}
