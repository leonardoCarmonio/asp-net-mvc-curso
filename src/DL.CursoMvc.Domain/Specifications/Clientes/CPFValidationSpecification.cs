using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Domain.ValueObjects;
using DomainValidation.Interfaces.Specification;

namespace DL.CursoMvc.Domain.Specifications.Clientes
{
    public class CPFValidationSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPF.Validar(cliente.CPF);
        }
    }
}
