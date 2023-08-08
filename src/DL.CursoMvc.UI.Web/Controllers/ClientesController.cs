using System;
using System.Web.Mvc;
using DL.CursoMvc.Application.Interfaces;
using DL.CursoMvc.Application.Services;
using DL.CursoMvc.Application.ViewModels;
using DL.CursoMvc.Infra.CrossCutting.Filters;
using DL.CursoMvc.UI.Web.Models;

namespace DL.CursoMvc.UI.Web.Controllers
{
    //[Authorize] Toda a controller é protegida 
    // Ao colocar esse atributo em cima da action, apenas ela será protegida

    [Authorize]
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class ClientesController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // [AllowAnonymous] Quando a classe estiver com o atributo Authorize
        //Podemos definir algumas actions que será aberta.

        //[AllowAnonymous]
        [ClaimsAuthorize("Clientes", "LI")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        [ClaimsAuthorize("Clientes", "DE")]
        [Route("{id:guid}/detalhes")] // Não precisa tratar conversão, só aceita do tipo guid
        public ActionResult Details(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "IN")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("Clientes", "IN")]
        [Route("criar-novo")]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (!ModelState.IsValid) return View(clienteEnderecoViewModel);

            var clienteEnd = _clienteAppService.Adicionar(clienteEnderecoViewModel);

            if (clienteEnd.Cliente.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(clienteEnd.Cliente.ValidationResult);

            return View(clienteEnderecoViewModel);

        }

        [ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null)
                return HttpNotFound();

            return View(clienteViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return View(clienteViewModel);

            _clienteAppService.Atualizar(clienteViewModel);
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Admin")]
        [ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null)
                return HttpNotFound();

            return View(clienteViewModel);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _clienteAppService.Dispose();
        }
    }
}
