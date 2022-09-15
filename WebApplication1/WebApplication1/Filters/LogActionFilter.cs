using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIPessoa.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //validação para update trocando metodo de validação por filtro

          //  if(!context.ModelState.isValid)
           // {
           //     context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
           // }

            if (!context.HttpContext.Request.Headers.Keys.Contains("Code"))
            {
                context.HttpContext.Request.Headers.Keys.Add(Guid.NewGuid().ToString());
            }
        }
    }
}
