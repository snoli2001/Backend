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
    public class DogOwnerDogWalksControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<DogWalk> _dogWalks; // lista utilizada para testear

        public DogOwnerDogWalksControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _dogWalks = getDogOwnerDogWalksSession(); // inicializando la lista de paseadores de perros que 
        }
        public List<DogWalk> getDogOwnerDogWalksSession()
        {
            var DogOwnerDog = new List<DogWalk>();
            DogOwnerDog.Add(new DogWalk
            {
                DogWalkId = 1,
                Hours = 5,
                AditionalInformation= "AditionalInformation 1",
                PaymentAmount = "10",
                DogWalkerId = 1,
                Date = DateTime.Now,
                Address = "casa1"
            });
            DogOwnerDog.Add(new DogWalk
            {
                DogWalkId = 2,
                Hours = 6,
                AditionalInformation = "AditionalInformation 2",
                PaymentAmount = "20",
                DogWalkerId = 2,
                Date = DateTime.Now,
                Address = "casa2"
            });
            return DogOwnerDog;
        }
        [Fact]
        public async Task GetDogOwnerDogWalksAsyncReturnAIEnumerableOfDogOwnerDogWalksModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogWalks.AddRange(_dogWalks); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new DogOwnerDogWalksController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetAllDogWalksByDogOwnerId(1); // llamando nuestro get

                //Assert
                Assert.False(typeof(IEnumerable<DogWalk>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                
            }
        }
    }
}
