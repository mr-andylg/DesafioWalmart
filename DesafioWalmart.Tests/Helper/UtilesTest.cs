using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWalmart.Tests.Helper
{
    [TestClass]
    public class UtilesTest
    {
        [TestMethod]
        public void EsPalindromoPalabra()
        {
            //clase estatica, no necesita arrange

            // Act
            bool result = DesafioWalmart.Helper.Utiles.EsPalindromo("reconocer");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EsPalindromoNumero()
        {
            //clase estatica, no necesita arrange

            // Act
            bool result = DesafioWalmart.Helper.Utiles.EsPalindromo("12344321");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NoEsPalindromoPalabra()
        {
            //clase estatica, no necesita arrange

            // Act
            bool result = DesafioWalmart.Helper.Utiles.EsPalindromo("dfjksh63knd3");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NoEsPalindromoNumero()
        {
            //clase estatica, no necesita arrange

            // Act
            bool result = DesafioWalmart.Helper.Utiles.EsPalindromo("1234567890");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NoEsPalindromoVacio()
        {
            //clase estatica, no necesita arrange

            // Act
            bool result = DesafioWalmart.Helper.Utiles.EsPalindromo(string.Empty);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
