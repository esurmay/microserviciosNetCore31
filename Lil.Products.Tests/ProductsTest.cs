using Lil.Products.Controllers;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Products.Tests
{
    [TestClass]
    public class ProductsTest
    {
        [TestMethod]
        public void GetAsyncReturnOk()
        {
            var productsProvider = new ProductsProvider();
            //is needed to pass the provider class to controller as a parameter
            var productsController = new ProductsController(productsProvider);

            var resultado = productsController.GetAsync("10").Result;

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));


        }

        [TestMethod]
        public void GetAsyncReturnNoFound()
        {
            var productsProvider = new ProductsProvider();
            //is needed to pass the provider class to controller as a parameter
            var productsController = new ProductsController(productsProvider);

            var resultado = productsController.GetAsync("101").Result;

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(NotFoundResult));
        }
    }
}
