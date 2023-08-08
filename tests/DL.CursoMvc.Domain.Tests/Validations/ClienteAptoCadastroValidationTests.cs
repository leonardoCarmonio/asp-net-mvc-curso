using DL.CursoMvc.Domain.Interfaces;
using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Domain.Tests.Validations
{
    [TestClass]
    public class ClienteAptoCadastroValidationTests
    {
        [TestMethod]
        public void ClienteApto_Validation_True()
        {
            // Arrange
            var cliente = new Cliente("Leonardo", "leonardo.carmonio@gmail.com", "02979958042",
                                       new DateTime(1989, 07, 19), true);

            // Mock
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(null);
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(null);

            var cliValidation = new ClienteEstaAptoParaCadastroValidation(repo);

            // Act
            var result = cliValidation.Validate(cliente);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ClienteApto_Validation_False()
        {
            // Arrange
            var cliente = new Cliente("Leonardo", "leonardo.carmonio@gmail.com", "02979958042",
                                       new DateTime(1989, 07, 19), true);

            // Mock
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(cliente);
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(cliente);

            var cliValidation = new ClienteEstaAptoParaCadastroValidation(repo);

            // Act
            var result = cliValidation.Validate(cliente);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Já existe um cliente com este CPF"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Já existe um cliente com este E-mail"));
        }
    }
}
