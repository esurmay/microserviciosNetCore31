using Lil.Customers.Controllers;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Customers.Tests
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void GetAsyncReturnOk()
        {
            var customerProvider = new CustomersProvider();
            //is needed to pass the provider class to controller as a parameter
            var customerController = new CustomersController(customerProvider);

            var resultado = customerController.GetAsync("1").Result;

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));


        }

        [TestMethod]
        public void GetAsyncReturnNoFound()
        {
            var customerProvider = new CustomersProvider();
            //is needed to pass the provider class to controller as a parameter
            var customerController = new CustomersController(customerProvider);

            var resultado = customerController.GetAsync("5").Result;

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(NotFoundResult));
        }
    }
}
