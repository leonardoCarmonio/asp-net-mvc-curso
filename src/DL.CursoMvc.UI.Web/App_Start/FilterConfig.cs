using DL.CursoMvc.Infra.CrossCutting.Filters;
using System.Web;
using System.Web.Mvc;

namespace DL.CursoMvc.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
