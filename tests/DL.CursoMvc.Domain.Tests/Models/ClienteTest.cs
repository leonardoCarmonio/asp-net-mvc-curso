using DL.CursoMvc.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Domain.Tests.Models
{
    [TestClass]
    public class ClienteTest
    {
        // AAA => Arrange, Act, Assert 

        [TestMethod]
        public void Cliente_EhValido_DeveRetornarValido()
        {
            // Arrange
            var cliente = new Cliente("Leonardo", "leonardo.carmonio@gmail.com", "02979958042",
                                       new DateTime(1989,07,19), true);

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_EhValido_DeveRetornarComErros()
        {
            // Arrange
            var cliente = new Cliente("Leonardo", "leonardo.carmoniogmail.com", "02979958046",
                                       DateTime.Now , true);

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(3, cliente.ValidationResult.Erros.Count());
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não tem maioridade para cadastro."));
        }
    }
}
