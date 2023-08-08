[assembly: WebActivator.PostApplicationStartMethod(typeof(DL.CursoMvc.UI.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace DL.CursoMvc.UI.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using DL.CursoMvc.Infra.CrossCutting.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            SimpleInjectorBoostrapper.Register(container);
        }
    }
}