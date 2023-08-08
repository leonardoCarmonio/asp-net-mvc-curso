using DL.CursoMvc.Application.Interfaces;
using DL.CursoMvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DL.CursoMvc.Rest.CursoApi.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods:"*")]
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: api/Clientes
        public IEnumerable<ClienteViewModel> Get()
        {
            return _clienteAppService.ObterAtivos();
        }

        // GET: api/Clientes/5
        public ClienteViewModel Get(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        // POST: api/Clientes
        public void Post([FromBody] ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            _clienteAppService.Adicionar(clienteEnderecoViewModel);
        }

        // PUT: api/Clientes/5
        public void Put(Guid id, [FromBody]ClienteViewModel clienteViewModel)
        {
            _clienteAppService.Atualizar(clienteViewModel);
        }

        // DELETE: api/Clientes/5
        public void Delete(Guid id)
        {
            _clienteAppService.Remover(id);
        }
    }
}
