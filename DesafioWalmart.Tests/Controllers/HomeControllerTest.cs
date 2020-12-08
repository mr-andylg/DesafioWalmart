using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesafioWalmart;
using DesafioWalmart.Controllers;

namespace DesafioWalmart.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ActionResult result = controller.Index() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListarProductos()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ActionResult result = controller.ListarProductos("nvn") as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        
    }
}
