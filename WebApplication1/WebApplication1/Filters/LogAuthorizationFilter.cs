using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIPessoa.Filters
{
    public class LogAuthorizationFilter : IAuthorizationFilter

    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("User", out var usuario);
            
            if(String.IsNullOrEmpty(usuario))
            {   //curto circuito e encerra todos os filtros

                context.Result = new StatusCodeResult((int)StatusCodes.Status401Unauthorized); 
            }
            throw new NotImplementedException();
        }
    }
}
