using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.DogOwnerNotification;
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
    public class DogOwnerNotificationsControllerTest
    {

        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<DogOwnerNotification> _dogownernotifications; // lista utilizada para testear

        public DogOwnerNotificationsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuraciÃ³n del builder al option
            _dogownernotifications = getDogOwnerNotificationsSession(); // inicializando la lista de paseadores de perros que 
        }

        [Fact]
        public async Task GetDogOwnerNotificationByIdReturnAIActionResultWithDogOwnerNotification()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogOwnerNotifications.AddRange(_dogownernotifications);
                _context.SaveChanges();

                var controller = new DogOwnerNotificationsController(_context);

                //Act
                var result = await controller.GetDogOwnerNotification(1);

                //Assert
                Assert.True(typeof(ActionResult<DogOwnerNotification>).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostDogOwnerNotificationReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateDogOwnerNotificationModel newDogOwnerNotification = new CreateDogOwnerNotificationModel
                {
                    Description = "una descripcion",
                };
                var controller = new DogOwnerNotificationsController(_context);

                //Act
                var result = await controller.PostDogOwnerNotification(1, newDogOwnerNotification);

                //Assert
                Assert.True(typeof(ActionResult<DogOwnerNotification>).IsInstanceOfType(result));
            }
        }

        public List<DogOwnerNotification> getDogOwnerNotificationsSession()
        {
            var dogownernotifications = new List<DogOwnerNotification>();
            dogownernotifications.Add(new DogOwnerNotification
            {
                DogOwnerNotificationId = 1,
                Description = "una descripcion",
                CreatedAt = DateTime.Now,
                DogOwnerId = 1
            });
            dogownernotifications.Add(new DogOwnerNotification
            {
                DogOwnerNotificationId = 2,
                Description = "una descripcion 2",
                CreatedAt = DateTime.Now,
                DogOwnerId = 1
            });
            return dogownernotifications;
        }
    }
}