using AutoMapper;
using DL.CursoMvc.Application.Interfaces;
using DL.CursoMvc.Application.ViewModels;
using DL.CursoMvc.Domain.Interfaces;
using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Infra.Data.Repository;
using DL.CursoMvc.Infra.Data.UoW;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Application.Services
{
    public class ClienteAppService : BaseService, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteRepository clienteRepository, IClienteService clienteService, 
                                 IUnitOfWork uow) : base(uow)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco =  Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.DefinirComoAtivo();
            cliente.AdicionarEndereco(endereco);

            var clienteRet = _clienteService.Adicionar(cliente);

            AdicionarResultadoProcessamento(clienteRet.ValidationResult);

            if (ValidacaoProcesso.IsValid)
            {
                if (!Commit())
                {
                    // fazer alguma coisa, log, excepction, add um erro para retornar ao cliente
                    clienteEnderecoViewModel.Cliente.ValidationResult.Add(new ValidationError("Ocorreu um erro no momento de salvar os dados no banco"));
                }
            }

            clienteEnderecoViewModel.Cliente = Mapper.Map<ClienteViewModel>(clienteRet);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            _clienteService.Atualizar(cliente);

            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
