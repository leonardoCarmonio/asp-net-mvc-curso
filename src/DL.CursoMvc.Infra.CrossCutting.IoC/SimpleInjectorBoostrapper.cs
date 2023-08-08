
using DL.CursoMvc.Application.Interfaces;
using DL.CursoMvc.Application.Services;
using DL.CursoMvc.Domain.Interfaces;
using DL.CursoMvc.Domain.Services;
using DL.CursoMvc.Infra.Data.Context;
using DL.CursoMvc.Infra.Data.Repository;
using DL.CursoMvc.Infra.Data.UoW;
using SimpleInjector;

namespace DL.CursoMvc.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBoostrapper
    {
        // Lifestyle.Transient => Uma instancia para cada solicitacao;
        // Lifestyle.Singleton => Uma instancia unica para a classe (para o servidor);
        // Lifestyle.Scoped => Uma instancia unica para o request;

        public static void Register(Container container)
        {
            // App
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            // Data
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMvcContext>(Lifestyle.Scoped);
        }
    }
}
