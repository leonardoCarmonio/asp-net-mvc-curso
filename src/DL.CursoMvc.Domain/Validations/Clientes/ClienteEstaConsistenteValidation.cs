using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Domain.Specifications.Clientes;
using DomainValidation.Validation;

namespace DL.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var clienteMaioridade = new ClienteDeveSerMaiorDeIdadeEspecificacion();
            var CPFCliente = new CPFValidationSpecification();
            var clienteEmail = new EmailValidoSpecification();

            base.Add("clienteMaioridade", new Rule<Cliente>(clienteMaioridade, "Cliente não tem maioridade para cadastro."));
            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido."));
            base.Add("ClienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido."));
        }
    }
}
