using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Domain.Tests.Specifications
{
    [TestClass]
    public class CpfSpecificationTests
    {
        [TestMethod]
        public void CpfSpecification_Valido_True()
        {
            // Arrange
            var cliente = new Cliente("Leonardo", "leonardo.carmonio@gmail.com", "02979958042",
                                       new DateTime(1989, 07, 19), true);

            var cpfSpec = new CPFValidationSpecification();

            //Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CpfSpecification_Valido_False()
        {
            // Arrange
            var cliente = new Cliente("Leonardo", "leonardo.carmonio@gmail.com", "02979958046",
                                       new DateTime(1989, 07, 19), true);

            var cpfSpec = new CPFValidationSpecification();

            //Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
