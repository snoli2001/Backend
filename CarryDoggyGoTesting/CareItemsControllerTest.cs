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
    public class CareItemsControllerTest
    {

        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<CareItem> _careItems; // lista utilizada para testear

        public CareItemsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _careItems = getCareItemsSession(); // inicializando la lista de paseadores de perros que 
        }

        [Fact]
        public async Task GetCareItemAsyncReturnAIEnumerableOfCareItemModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.CareItems.AddRange(_careItems); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new CareItemsController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetCareItems(); // llamando nuestro get

                //Assert
                Assert.True(typeof(IEnumerable<CaresItemModel>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }

        [Fact]
        public async Task GetCareItemByIdReturnAIActionResultWithCareItem()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.CareItems.AddRange(_careItems);
                _context.SaveChanges();

                var controller = new CareItemsController(_context);

                //Act
                var result = await controller.GetCaresItemById(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostCareitemReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateCareitemModel newCareItem = new CreateCareitemModel
                {
                    Name = "Test1",
                    Description = "una descripcion",
                };
                var controller = new CareItemsController(_context);

                //Act
                var result = await controller.PostCareItem(newCareItem);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PutCareItemReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.CareItems.AddRange(_careItems);
                _context.SaveChanges();
                UpdateCareItemModel updateCareItem = new UpdateCareItemModel
                {
                    Name = "Test1",
                    Description = "una descripcion"
                };
                var controller = new CareItemsController(_context);

                //Act
                var result = await controller.PutCareItem(1, updateCareItem);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task DeleteCareItemReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.CareItems.AddRange(_careItems);
                _context.SaveChanges();
                var controller = new CareItemsController(_context);

                //Act
                var result = await controller.Delete(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        public List<CareItem> getCareItemsSession()
        {
            var careItems = new List<CareItem>();
            careItems.Add(new CareItem
            {
                CareItemId = 1,
                Name = "Test1",
                Description = "una descripcion",
            });
            careItems.Add(new CareItem
            {
                CareItemId = 2,
                Name = "Test2",
                Description = "una descripcion dos",
            });
            return careItems;
        }
    }
}
