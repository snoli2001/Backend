using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.District;
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
    public class CityDisctricsControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<City> _citydistrict; // lista utilizada para testear

        public CityDisctricsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _citydistrict = getCityDistricsSession(); // inicializando la lista de paseadores de perros que 
        }


        [Fact]
        public async Task GetCityDistrictsByIdReturnAIActionResultWithCityDistrict()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Cities.AddRange(_citydistrict);
                _context.SaveChanges();

                var controller = new CityDistrictsController(_context);

                //Act
                var result = await controller.GetDistrictsByCityId(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }
        [Fact]
        public async Task PostCityDisctrictReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateDistrictModel newCityDistrict = new CreateDistrictModel
                {
                    Name = "Test1"
                   
                };
                var controller = new CityDistrictsController(_context);

                //Act
                var result = await controller.Post(1,newCityDistrict);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }
        public List<City> getCityDistricsSession()
        {
            var cityDistricts = new List<City>();
            cityDistricts.Add(new City
            {
                CityId = 1,
                Name = "Test1"
                
            });
            cityDistricts.Add(new City
            {
                CityId = 2,
                Name = "Test2"
              
            });
            return cityDistricts;
        }

    }
}
