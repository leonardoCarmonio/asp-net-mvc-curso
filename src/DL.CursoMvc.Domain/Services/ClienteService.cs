using DL.CursoMvc.Domain.Interfaces;
using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Domain.Validations.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido()) return cliente;

            cliente.ValidationResult = new ClienteEstaAptoParaCadastroValidation(_clienteRepository).Validate(cliente);

            return cliente.ValidationResult.IsValid ? _clienteRepository.Adicionar(cliente) : cliente;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return cliente;

            return _clienteRepository.Atualizar(cliente);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {

        }
    }
}
