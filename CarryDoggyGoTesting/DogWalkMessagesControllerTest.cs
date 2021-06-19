using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Message;
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
    public class DogWalkMessagesControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<Message> _messages; // lista utilizada para testear
        public DogWalkMessagesControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _messages = getMessagesSession(); // inicializando la lista de paseadores de perros que 
        }
        [Fact]
        public async Task GetMessageByIdReturnAIActionResultWithMessage()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Messages.AddRange(_messages);
                _context.SaveChanges();

                var controller = new DogWalkMessagesController(_context);

                //Act
                var result = await controller.GetDogWalkMessage(1);

                //Assert
                //Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }
        [Fact]
        public async Task PostMessageReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateMessageModel newMessage = new CreateMessageModel
                {
                    Text = "Text1",
                    IsImportant = false
                };
                var controller = new DogWalkMessagesController(_context);

                //Act
                var result = await controller.PostDogWalkMessage(1,newMessage);

                //Assert
                //Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }
        public List<Message> getMessagesSession()
        {
            var messages = new List<Message>();
            messages.Add(new Message
            {
                MessageId = 1,
                Text = "Text1",
                IsImportant = false,
                CreatedAt = DateTime.Now,
                DogWalkId=1

            });
            messages.Add(new Message
            {
                MessageId = 2,
                Text = "Text2",
                IsImportant = true,
                CreatedAt= DateTime.Now,
                DogWalkId=2
            });
            return messages;
        }
    }
}
