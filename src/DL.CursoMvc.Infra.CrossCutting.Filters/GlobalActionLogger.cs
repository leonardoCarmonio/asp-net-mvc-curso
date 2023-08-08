using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DL.CursoMvc.Infra.CrossCutting.Filters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // LOG de Auditoria

            if (filterContext.Exception != null)
            {
                // Manipular a Ex
                // Injetar alguma LIB de tratamento de erro
                // Gravar log de erro no BD
                // Email para o admin
                // Retornar cod de erro amigavel

                // SEMPRE USE ASYNC AQUI DENTRO

                // Estamos informando que a exceção foi tratada
                filterContext.ExceptionHandled = true;

                // Estamos retornando o erro 500 como resposta
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
