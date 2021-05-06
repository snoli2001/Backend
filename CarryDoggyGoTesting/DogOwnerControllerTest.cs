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
    public class DogOwnerControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options;
        private readonly List<DogOwner> _dogOwners;

        public DogOwnerControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _dogOwners = getDogOwnersSession();
        }


        //[Fact]
        //public async Task GetDogWalkerAsyncReturnAIEnumerableOfDogWalkerModel()
        //{
        //    using (var _context = new DbContextCarryDoggyGo(_options))
        //    {
        //        //Arrange
        //        _context.DogOwners.AddRange(_dogOwners);
        //        _context.SaveChanges();

        //        var controller = new DogOwnersController(_context);

        //        //Act
        //        var result = await controller.Get();

        //        //Assert
        //        Assert.True(typeof(IEnumerable<DogOwnerModel>).IsInstanceOfType(result));
        //        Assert.Equal(2, result.Count());
        //    }

        //}

        //[Fact]
        //public async Task GetDogWalkerByIdReturnAIActionResultWithDogWalker()
        //{
        //    using (var _context = new DbContextCarryDoggyGo(_options))
        //    {
        //        //Arrange
        //        _context.DogOwners.AddRange(_dogOwners);
        //        _context.SaveChanges();

        //        var controller = new DogWalkersController(_context);

        //        //Act
        //        var result = await controller.GetDogWalkerById(1);

        //        //Assert
        //        Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
        //    }
        //}

        //[Fact]
        //public async Task PostDogWalkerReturnAnOkObjectResult()
        //{
        //    using (var _context = new DbContextCarryDoggyGo(_options))
        //    {
        //        //Arrange
        //        CreateDogWalkerModel newDogWalker = new CreateDogWalkerModel
        //        {
        //            Name = "test",
        //            LastName = "test",
        //            Phone = "987654321",
        //            Email = "test@test.com",
        //            Description = "soy una descripcion",
        //            PaymentAmount = 40
        //        };
        //        var controller = new DogWalkersController(_context);

        //        //Act
        //        var result = await controller.PostDogWalker(newDogWalker);

        //        //Assert
        //        Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
        //    }
        //}

        //[Fact]
        //public async Task PutDogWalkerReturnAnOkObjectResult()
        //{
        //    using (var _context = new DbContextCarryDoggyGo(_options))
        //    {
        //        //Arrange
        //        _context.DogWalkers.AddRange(_dogWalkers);
        //        _context.SaveChanges();
        //        UpdateDogWalkerModel updateDogWalker = new UpdateDogWalkerModel
        //        {
        //            Name = "test",
        //            LastName = "test",
        //            Phone = "987654321",
        //            Password = "12345678",
        //            Description = "soy una descripcion",
        //            PaymentAmount = 50
        //        };
        //        var controller = new DogWalkersController(_context);

        //        //Act
        //        var result = await controller.PutDogWalker(1, updateDogWalker);

        //        //Assert
        //        Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
        //    }
        //}

        //[Fact]
        //public async Task DeleteDogWalkerReturnAnOkObjectResult()
        //{
        //    using (var _context = new DbContextCarryDoggyGo(_options))
        //    {
        //        //Arrange
        //        _context.DogWalkers.AddRange(_dogWalkers);
        //        _context.SaveChanges();
        //        var controller = new DogWalkersController(_context);

        //        //Act
        //        var result = await controller.Delete(1);

        //        //Assert
        //        Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
        //    }
        //}

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

