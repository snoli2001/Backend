using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Location;
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
    public class LocationsControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<Location> _locations; // lista utilizada para testear

        public LocationsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _locations = getLocationsSession(); // inicializando la lista de paseadores de perros que 
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
        public async Task GetLocationsAsyncReturnAIEnumerableOfCLocationsModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Locations.AddRange(_locations); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new LocationsController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetLocations(); // llamando nuestro get

                //Assert
                Assert.True(typeof(IEnumerable<LocationModel>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }

        [Fact]
        public async Task GetLocationsByIdReturnAIActionResultWithLocations()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Locations.AddRange(_locations);
                _context.SaveChanges();

                var controller = new LocationsController(_context);

                //Act
                var result = await controller.GetLocationById(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostLocationsReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateLocationModel newLocations = new CreateLocationModel
                {
                    Address = "Address",
                    NumX = 720,
                    NumY = 480,
                    DistrictId = 1
                };
                var controller = new LocationsController(_context);

                //Act
                var result = await controller.PostLocation(newLocations);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PutLocationReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Locations.AddRange(_locations);
                _context.SaveChanges();
                UpdateLocationModel updateLocations= new UpdateLocationModel
                {
                    Address = "Address4",
                    NumX = 1080,
                    NumY = 1000
                };
                var controller = new LocationsController(_context);

                //Act
                var result = await controller.PutLocation(1, updateLocations);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task DeleteLocationsReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Locations.AddRange(_locations);
                _context.SaveChanges();
                var controller = new LocationsController(_context);

                //Act
                var result = await controller.DeleteLocation(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }


    }

}
