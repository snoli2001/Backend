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
    public class DogCareItemsControllerTest
    {

        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<CareItem> _careItems; // lista utilizada para testear
        private readonly List<DogCareItem> _dogcareItems;
        public DogCareItemsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuraciÃ³n del builder al option
            _careItems = getCareItemsSession(); // inicializando la lista de paseadores de perros que 
            _dogcareItems = getDogCareItemsSession();
        }

        [Fact]
        public async Task PatchDogCareItemByDogIdAndCareItemIdReturnAIActionResultWithDogCareItem()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogCareItems.AddRange(_dogcareItems);
                _context.SaveChanges();

                var controller = new DogCareItems(_context);

                //Act
                var result = await controller.AssignItems(1, 1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }

        }

        [Fact]
        public async Task GetDogCareItemByDogIdReturnAIActionResultWithDogCareItem()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.CareItems.AddRange(_careItems);
                _context.SaveChanges();

                var controller = new DogCareItems(_context);

                //Act
                var result = await controller.GetCareItems(1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
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

        public List<DogCareItem> getDogCareItemsSession()
        {
            var dogcareItems = new List<DogCareItem>();
            dogcareItems.Add(new DogCareItem
            {
                CareItemId = 1,
                DogId = 1
            });
            dogcareItems.Add(new DogCareItem
            {
                CareItemId = 2,
                DogId = 1
            });
            return dogcareItems;
        }
    }
}