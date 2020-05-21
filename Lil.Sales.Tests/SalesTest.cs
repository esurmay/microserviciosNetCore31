using Lil.Sales.Controllers;
using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Sales.Tests
{
    [TestClass]
    public class SalesTest
    {
        [TestMethod]
        public void GetAsyncReturnOk()
        {
            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);
            var resultado = salesController.GetAsync("3").Result;

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnNoFound()
        {
            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);
            var resultado = salesController.GetAsync("101").Result;

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(NotFoundResult));
        }
    }
}
