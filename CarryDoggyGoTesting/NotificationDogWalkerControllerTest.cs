using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.NotificationDogWalker;
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
    public class NotificationDogWalkerControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<NotificationDogWalker> _notificationdogwalkers; // lista utilizada para testear

        public NotificationDogWalkerControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _notificationdogwalkers = getNotificationDogWalkersSession(); // inicializando la lista de paseadores de perros que 
        }

        [Fact]
        public async Task GetNotificationDogWalkerAsyncReturnAIEnumerableOfNotificationDogWalkerModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.NotificationDogWalkers.AddRange(_notificationdogwalkers); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new NotificationDogWalkersController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetNotificationDogWalkers(); // llamando nuestro get

                //Assert
                //Assert.True(typeof(IEnumerable<NotificationDogWalkerModel>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                //Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }

        [Fact]
        public async Task GetNotificationDogWalkerByIdReturnAIActionResultWithNotificationDogWalker()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.NotificationDogWalkers.AddRange(_notificationdogwalkers);
                _context.SaveChanges();

                var controller = new NotificationDogWalkersController(_context);

                //Act
                var result = await controller.GetNotificationDogWalker(1);

                //Assert
                //Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostNotificationDogWalkerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateNotificationDogWalkerModel newNotificationDogWalker = new CreateNotificationDogWalkerModel
                {
                    DogWalkerId = 1,
                    ShippingDate = DateTime.Now,
                    Description = "una descripcion",
                    //AcceptDeny = true
                };
                var controller = new NotificationDogWalkersController(_context);

                //Act
                var result = await controller.PostNotificationDogWalker(newNotificationDogWalker);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PutNotificationDogWalkerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.NotificationDogWalkers.AddRange(_notificationdogwalkers);
                _context.SaveChanges();
                UpdateNotificationDogWalker updateNotificationDogWalker = new UpdateNotificationDogWalker
                {
                    AcceptDeny = false
                };
                var controller = new NotificationDogWalkersController(_context);

                //Act
                var result = await controller.PutNotificationDogWalker(1, updateNotificationDogWalker);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task DeleteNotificationDogWalkerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.NotificationDogWalkers.AddRange(_notificationdogwalkers);
                _context.SaveChanges();
                var controller = new NotificationDogWalkersController(_context);

                //Act
                var result = await controller.DeleteNotificationDogWalker(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        public List<NotificationDogWalker> getNotificationDogWalkersSession()
        {
            var notificationdogwalkers = new List<NotificationDogWalker>();
            notificationdogwalkers.Add(new NotificationDogWalker
            {
                NotificationDogWalkerId = 1,
                DogWalkerId = 1,
                ShippingDate = DateTime.Now,
                Description = "una descripcion",
                AcceptDeny = true
            });
            notificationdogwalkers.Add(new NotificationDogWalker
            {
                NotificationDogWalkerId = 2,
                DogWalkerId = 1,
                ShippingDate = DateTime.Now,
                Description = "una descripcion",
                AcceptDeny = false
            });
            return notificationdogwalkers;
        }
    }
}
