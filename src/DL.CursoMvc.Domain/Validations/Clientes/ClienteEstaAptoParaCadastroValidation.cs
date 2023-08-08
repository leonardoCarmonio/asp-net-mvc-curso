using DL.CursoMvc.Domain.Interfaces;
using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Domain.Specifications.Clientes;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteEstaAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteEstaAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var clienteUnicoCpf = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var clienteUnicoEmail = new ClienteDeveTerEmailUnicoSpecification(clienteRepository);

            base.Add("clienteUnicoCpf", new Rule<Cliente>(clienteUnicoCpf, "Já existe um cliente com este CPF"));
            base.Add("clienteUnicoEmail", new Rule<Cliente>(clienteUnicoCpf, "Já existe um cliente com este E-mail"));
        }
    }
}
