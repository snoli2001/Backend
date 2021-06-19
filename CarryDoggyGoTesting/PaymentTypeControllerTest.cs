using CarryDoggyGo.Controllers;
using CarryDoggyGo.Data;
using CarryDoggyGo.Entities;
using CarryDoggyGo.Models.PaymentType;
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
    public class PaymentTypeControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextCarryDoggyGo> _builder = new DbContextOptionsBuilder<DbContextCarryDoggyGo>();  // builder necesario para crear nuestra base de datos ficticia
        private readonly DbContextOptions<DbContextCarryDoggyGo> _options; // options para construir nuestro DbContext en memoria
        private readonly List<PaymentType> _paymentTypes; // lista utilizada para testear

        public PaymentTypeControllerTest()
        {
            _builder.UseInMemoryDatabase("Test"); // nombre de la base de datos ficticia
            _options = _builder.Options;// pasando la configuración del builder al option
            _paymentTypes = getPaymentSession(); // inicializando la lista de paseadores de perros que 

        }
        public List<PaymentType> getPaymentSession()
        {
            var paymentTypes = new List<PaymentType>();
            paymentTypes.Add(new PaymentType
            {
                PaymentTypeId = 1,
                Name = "Type1"
                });
            paymentTypes.Add(new PaymentType
            {
                PaymentTypeId = 2,
                Name = "Type2"
            });
            return paymentTypes;
        }
        //1
        [Fact]
        public async Task GetPaymentAsyncReturnAIEnumerableOfPaymentModel()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.PaymentTypes.AddRange(_paymentTypes); // añadiendo la lista en la base de datos ficticia con la lista de perros de testeo
                _context.SaveChanges(); // guardando en la base de datos

                var controller = new PaymentTypesController(_context); // inicializando nuestro controlador 

                //Act
                var result = await controller.GetPaymentTypes(); // llamando nuestro get

                //Assert
                Assert.False(typeof(IEnumerable<PaymentType>).IsInstanceOfType(result)); // verificando que nuestro método get retorne el resultado esperado
                Assert.Equal(2, result.Count()); // ya que nuestra lista de paseadores de perros que le pasamos contiene 2 paseadores de perro verificamos que nuestro método también retorne 2 paseadores 
            }
        }
        //2
        [Fact]
        public async Task GetPaymentByIdReturnAIActionResultWithDog()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.PaymentTypes.AddRange(_paymentTypes);
                _context.SaveChanges();

                var controller = new PaymentTypesController(_context);

                //Act
                var result = await controller.GetPaymentTypeById(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        //3
        [Fact]
        public async Task PutPaymentReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.PaymentTypes.AddRange(_paymentTypes);
                _context.SaveChanges();
                UpdatePaymentTypeModel updatePaymentModel = new UpdatePaymentTypeModel
                {
                    Name = "Payment1"
                    
                };
                var controller = new PaymentTypesController(_context);

                //Act
                var result = await controller.PutPaymentType(1, updatePaymentModel);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

        [Fact]
        public async Task DeletePaymentReturnAnOkObjectResult()
        {
            using (var _context = new DbContextCarryDoggyGo(_options))
            {
                //Arrange
                _context.PaymentTypes.AddRange(_paymentTypes);
                _context.SaveChanges();
                var controller = new PaymentTypesController(_context);

                //Act
                var result = await controller.Delete(1);

                //Assert
                Assert.True(typeof(OkObjectResult).IsInstanceOfType(result));
            }
        }

    }

}

