using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.DogWalk;
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
    public class DogWalksControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<DogWalk> _dogWalks; // lista utilizada para testear

        public DogWalksControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _dogWalks = getDogWalksSession(); // inicializando la lista de paseadores de perros que 
        }

        [Fact]
        public async Task GetDogWalksByIdReturnAIActionResultWithDogWalks()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalks.AddRange(_dogWalks);
                _context.SaveChanges();

                var controller = new DogWalksController(_context);

                //Act
                var result = await controller.GetDogWalkers(2);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostDogWalksReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateDogWalkModel newDogWalks = new CreateDogWalkModel
                {
                    Hours = 2,
                    Address = "av. viru",
                    AditionalInformation = "Informacion 1",
                    PaymentAmount = "30",
                    DogWalkerId=1,
                    Date = DateTime.Now
                };
                var controller = new DogWalksController(_context);

                //Act
                var result = await controller.PostDogWalkers(newDogWalks);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        /*[Fact]
        public async Task PatchDogWalksInProgress()
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
        }*/

        public List<DogWalk> getDogWalksSession()
        {
            var dogWalks = new List<DogWalk>();
            dogWalks.Add(new DogWalk
            {
                DogWalkerId = 1,
                DogWalkId = 1,
                Hours = 2,
                Address = "av. viru",
                AditionalInformation = "Informacion 1",
                PaymentAmount = "30",
                Date = DateTime.Now

            });
            dogWalks.Add(new DogWalk
            {
                DogWalkerId = 2,
                DogWalkId = 2,
                Hours = 3,
                Address = "av. piru",
                AditionalInformation = "Informacion 2",
                PaymentAmount = "20",
                Date = DateTime.Now
            });
            return dogWalks;
        }
    }
}
