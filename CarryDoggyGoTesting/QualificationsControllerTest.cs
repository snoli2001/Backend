using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.QualificationModel;
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
    public class QualificationsControllerTest
    {

        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<Qualification> _califications; // lista utilizada para testear

        public QualificationsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _califications = getQualificationsSession(); // inicializando la lista de paseadores de perros que 
        }

        [Fact]
        public async Task GetQualificationAsyncReturnAIEnumerableOfQualificationModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Qualifications.AddRange(_califications); // añadiendo la lista en la base de datos ficticia con la lista de paseadores de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new QualificationsController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetQualification(); // llamando nuestro get

                //Assert
                Assert.True(typeof(IEnumerable<QualificationModel>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }

        //TODO
        //[Fact]
        //public async Task GetQualificationByIdReturnAIActionResultWithQualification()
        //{
        //    using (var _context = new DbContextCarryDoggyGo(_options))
        //    {
        //        //Arrange
        //        _context.Qualifications.AddRange(_califications);
        //        _context.SaveChanges();

        //        var controller = new QualificationsController(_context);

        //        //Act
        //        var result = await controller.GetQualificationById(1);

        //        //Assert
        //        Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
        //    }
        //}

        //TODO
        [Fact]
        public async Task PostQualificationReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateQualificationModel newQualification = new CreateQualificationModel
                {
                    Starts = 1,
                    Recomendations = "una recomendacion",
                };
                var controller = new QualificationsController(_context);

                //Act
                var result = await controller.PostQualification(1, newQualification);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        //TODO
        //[Fact]
        //public async Task PutQualificationReturnAnOkObjectResult()
        //{
        //    using (var _context = new DbContextCarryDoggyGo(_options))
        //    {
        //        //Arrange
        //        _context.Qualifications.AddRange(_califications);
        //        _context.SaveChanges();
        //        UpdateQualificationModel updateQualification = new UpdateQualificationModel
        //        {
        //            Starts = 3,
        //            Recomendations = "una recomendacion 3"
        //        };
        //        var controller = new QualificationsController(_context);

        //        //Act
        //        var result = await controller.PutQualification(1, updateQualification);

        //        //Assert
        //        Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
        //    }
        //}

        //TODO
        //[Fact]
        //public async Task DeleteQualificationReturnAnOkObjectResult()
        //{
        //    using (var _context = new DbContextCarryDoggyGo(_options))
        //    {
        //        //Arrange
        //        _context.Qualifications.AddRange(_califications);
        //        _context.SaveChanges();
        //        var controller = new QualificationsController(_context);

        //        //Act
        //        var result = await controller.DeleteQualification(1);

        //        //Assert
        //        Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
        //    }
        //}

        public List<Qualification> getQualificationsSession()
        {
            var califications = new List<Qualification>();
            califications.Add(new Qualification
            {
                QualificationId = 1,
                Starts = 1,
                Recomendations = "una recomendacion",
            });
            califications.Add(new Qualification
            {
                QualificationId = 2,
                Starts = 2,
                Recomendations = "una recomendacion 2",
            });
            return califications;
        }
    }
}

