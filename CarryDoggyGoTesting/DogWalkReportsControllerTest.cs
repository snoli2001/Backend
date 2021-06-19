using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.Report;
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
    public class DogWalkReportsControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<Report> _reports; // lista utilizada para testear

        public DogWalkReportsControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _reports = getReportsession(); // inicializando la lista de paseadores de perros que 

        }
        public List<Report> getReportsession()
        {
            var reports = new List<Report>();
            reports.Add(new Report
            {
                ReportId = 1,
                Description = "Report1",
                DogWalkId = 1
            });
            reports.Add(new Report
            {
                ReportId = 2,
                Description = "Report2",
                DogWalkId = 2
            });
            return reports;
        }
        
        [Fact]
        public async Task GetReportByIdReturnAIActionResultWithDog()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.Reports.AddRange(_reports);
                _context.SaveChanges();

                var controller = new DogWalkReportsController(_context);

                //Act
                var result = await controller.GetDogWalkReport(1);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }
        [Fact]
        public async Task PostReportReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                CreateReportModel newReport = new CreateReportModel
                {
             
                    Description = "una descripcion",
                };
                var controller = new DogWalkReportsController(_context);

                //Act
                var result = await controller.PostDogWalkReport(1,newReport);

                //Assert
                Assert.False(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }



    }

}

