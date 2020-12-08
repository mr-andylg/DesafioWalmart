using DesafioWalmart.Data;
using DesafioWalmart.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWalmart.Tests.Data
{
    [TestClass]
    public class ProductosDataTest
    {
        [TestMethod]
        public void TraerDatosTodos()
        {
            // Arrange
            ProductosData pd = new ProductosData();
            List<Producto> listaAux = new List<Producto>();

            // Act
            List<Producto> result = pd.BuscarProducto(string.Empty);

            // Assert
            Assert.IsInstanceOfType(result, listaAux.GetType());
        }

        [TestMethod]
        public void TraerDatosAlgunos()
        {
            // Arrange
            ProductosData pd = new ProductosData();

            // Act
            bool result = DesafioWalmart.Helper.Utiles.EsPalindromo("reconocer");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SinDatos()
        {
            /// Arrange
            ProductosData pd = new ProductosData();

            // Act
            bool result = DesafioWalmart.Helper.Utiles.EsPalindromo("reconocer");

            // Assert
            Assert.IsTrue(result);
        }
    }
}
