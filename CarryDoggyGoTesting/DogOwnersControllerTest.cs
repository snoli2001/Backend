using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.DogOwner;
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
    public class DogOwnersControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options;
        private readonly List<DogOwner> _dogOwners;

        public DogOwnersControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _dogOwners = getDogOwnersSession();
        }


        [Fact]
        public async Task GetDogOwnerrAsyncReturnAIEnumerableOfDogOwnerModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogOwners.AddRange(_dogOwners);
                _context.SaveChanges();
                var controller = new DogOwnersController(_context);
                //Act
                var result = await controller.Get();
                //Assert
                Assert.True(typeof(IEnumerable<DogOwnerModel>).IsInstanceOfType(result));
                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public async Task GetDogOwnerByIdReturnAIActionResultWithDogOwner()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {

                //Arrange
                _context.DogOwners.AddRange(_dogOwners);
                _context.SaveChanges();

                var controller = new DogOwnersController(_context);

                //Act
                var result = await controller.GetById(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PostDogOwnerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateDogOwnerModel newDogOwner = new CreateDogOwnerModel
                {
                    Name = "test",
                    LastName = "test",
                    Phone = "987654321",
                    Email = "test@test.com",
                    Password = "123456"
                };
                var controller = new DogOwnersController(_context);

                //Act
                var result = await controller.PostAsync(newDogOwner);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task PutDogOwnerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogOwners.AddRange(_dogOwners);
                _context.SaveChanges();
                UpdateDogownerModel updateDogOwner = new UpdateDogownerModel
                {
                    Name = "test",
                    LastName = "test",
                    Phone = "987654321",
                    Password = "12345678",
                };
                var controller = new DogOwnersController(_context);

                //Act
                var result = await controller.PutDogOwner(1, updateDogOwner);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task DeleteDogOwnerReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.DogOwners.AddRange(_dogOwners);
                _context.SaveChanges();
                var controller = new DogOwnersController(_context);

                //Act
                var result = await controller.Delete(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        public List<DogOwner> getDogOwnersSession()
        {
            var dogOwners = new List<DogOwner>();
            dogOwners.Add(new DogOwner
            {
                DogOwnerId = 1,
                Name = "Test1",
                LastName = "One",
                Email = "test@gmail.com",
                Phone = "987654321",
                Password = "123456"

            });
            dogOwners.Add(new DogOwner
            {
                DogOwnerId = 2,
                Name = "Test2",
                LastName = "Two",
                Email = "test@gmail.com",
                Phone = "987654321",
                Password = "123456"

            });
            return dogOwners;
        }
    }
}

